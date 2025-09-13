    using Data.Entities.Identity;
using Data.Helpers;
using infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Service.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepo _refreshTokenRepo;
        private readonly UserManager<User> _userManager;
    //    private readonly IEmailsService _emailsService;
        private readonly AppDbContext _applicationDBContext;
     //   private readonly IEncryptionProvider _encryptionProvider;
        public AuthenticationService(JwtSettings jwtSettings, IRefreshTokenRepo refreshTokenRepo, 
            UserManager<User> userManager, AppDbContext applicationDBContext)
        {
            _jwtSettings = jwtSettings;
            _refreshTokenRepo = refreshTokenRepo;
            _userManager=userManager;
            _applicationDBContext=applicationDBContext;
        }
        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var (jwtToken, accessToken) = await GenerateJWTToken(user);
            var refreshtoken = GetRefreshToken(user.UserName);
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiredDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = true,
                IsRevoked = false,
                JwtId = jwtToken.Id,
                RefreshToken = refreshtoken.TokenString,
                Token = accessToken,
                UserId = user.Id
            };
            await _refreshTokenRepo.AddAsync(userRefreshToken);
            var response = new JwtAuthResult();
            response.refreshToken = refreshtoken;
            response.AccessToken = accessToken;
            return response;

        }
        private async Task<(JwtSecurityToken, string)> GenerateJWTToken(User user)
        {
            var claims = await GetClaim(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        private RefreshToken GetRefreshToken(string UserName)
        {
            var refreshtoken = new RefreshToken()
            {
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = UserName,
                TokenString = GenerateRefreshToken()
            };


            return refreshtoken;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public async Task< List<Claim>> GetClaim(User user)
        {
            var Claim = new List<Claim>()
            {
                new Claim (nameof( UserClaimModel.UserName),user.UserName) ,
                new Claim (nameof( UserClaimModel.Email),user.Email) ,
                new Claim (nameof( UserClaimModel.PhoneNumber),user.PhoneNumber),
                new Claim (nameof( UserClaimModel.Id),user.Id.ToString())
            };
            return Claim;
        }

        public async Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        {
            var (jwtSecurityToken, newToken) = await GenerateJWTToken(user);
            var response = new JwtAuthResult();
            response.AccessToken = newToken;
            var refreshTokenResult = new RefreshToken();
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
            refreshTokenResult.TokenString = refreshToken;
            refreshTokenResult.ExpireAt = (DateTime)expiryDate;
            response.refreshToken = refreshTokenResult;
            return response;

        }

        public JwtSecurityToken ReadJWTToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }
    
    
        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "InvalidToken";
                }

                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("AlgorithmIsWrong", null);
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("TokenIsNotExpired", null);
            }

            //Get User

            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;
            var userRefreshToken = await _refreshTokenRepo.GetTableNoTracking()
                                             .FirstOrDefaultAsync(x => x.Token == AccessToken &&
                                                                     x.RefreshToken == RefreshToken &&
                                                                     x.UserId == int.Parse(userId));
            if (userRefreshToken == null)
            {
                return ("RefreshTokenIsNotFound", null);
            }

            if (userRefreshToken.ExpiredDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepo.UpdateAsync(userRefreshToken);
                return ("RefreshTokenIsExpired", null);
            }
            var expirydate = userRefreshToken.ExpiredDate;
            return (userId, expirydate);
        }

        public async Task<string> ConfirmEmail(int? userId, string? code)
        {
            if (userId == null || code == null)
                return "ErrorWhenConfirmEmail";
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);
            if (!confirmEmail.Succeeded)
                return "ErrorWhenConfirmEmail";
            return "Success";
        }

        public async Task<string> SendResetPasswordCode(string Email)
        {
            throw new NotImplementedException();

            //    var trans = await _app.Database.BeginTransactionAsync();
            //    try
            //    {
            //        //user
            //        var user = await _userManager.FindByEmailAsync(Email);
            //        //user not Exist => not found
            //        if (user == null)
            //            return "UserNotFound";
            //        //Generate Random Number

            //        //Random generator = new Random();
            //        //string randomNumber = generator.Next(0, 1000000).ToString("D6");
            //        var chars = "0123456789";
            //        var random = new Random();
            //        var randomNumber = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            //        //update User In Database Code
            //        user. = randomNumber;
            //        var updateResult = await _userManager.UpdateAsync(user);
            //        if (!updateResult.Succeeded)
            //            return "ErrorInUpdateUser";
            //        var message = "Code To Reset Passsword : " + user.Code;
            //        //Send Code To  Email 
            //        await _emailsService.SendEmail(user.Email, message, "Reset Password");
            //        await trans.CommitAsync();
            //        return "Success";
            //    }
            //    catch (Exception ex)
            //    {
            //        await trans.RollbackAsync();
            //        return "Failed";
            //    }
        }

        public Task<string> ConfirmResetPassword(string Code, string Email)
        {
            throw new NotImplementedException();
        }

        public Task<string> ResetPassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }
    }
    }
