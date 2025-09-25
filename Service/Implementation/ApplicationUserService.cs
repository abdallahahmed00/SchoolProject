using Data.Entities.Identity;
using infrastructure.Data;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailsService;
        private readonly AppDbContext _applicationDBContext;
        private readonly IUrlHelper _urlHelper;
       
        public ApplicationUserService(UserManager<User> userManager,
                                      IHttpContextAccessor httpContextAccessor,
                                      IEmailService emailsService,
                                      AppDbContext applicationDBContext,
                                      IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _applicationDBContext = applicationDBContext;
            _urlHelper = urlHelper;
        }
        public async Task<string> AddUserAsync(User user, string password)
        {

            var trans = await _applicationDBContext.Database.BeginTransactionAsync();
            try
            {
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                if (existUser != null)
                {
                    return "EmailIsExist";
                }
                var userByUserName = await _userManager.FindByNameAsync(user.UserName);
                if (userByUserName != null)
                {
                    return "UserNameIsExist";
                }
                var createResult = await _userManager.CreateAsync(user, password);
                if (!createResult.Succeeded)
                {
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());
                }
                await _userManager.AddToRoleAsync(user, "User");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id,code = code });
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
                await _emailsService.SendEmail(user.Email, message, "ConFirm Email");

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }

        }
    }
}
