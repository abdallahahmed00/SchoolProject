using Core;
using Core.Features.User.Commands.Models;
using Core.Features.User.Commands.Validations;
using Core.Filters;
using Data.Entities;
using Data.Entities.Identity;
using FluentValidation;
using infrastructure.Data;
using infrastructure.Interface;
using infrastructure.Repositires;
using Infrastructure;
using Infrastructure.Seedor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Service;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddInfrastructureDependencies().
                 AddServiceDependencies().
                 AddCoreDependencies()
                 .AddServiceRegisteration((builder.Configuration));
    
var cors = "_Cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,

        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        })  ;

});

builder.Services.AddScoped<IValidator<AddUserCommand>, AddUserValiator>();


builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddTransient<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});

builder.Services.AddTransient<AuthFilter>();

Log.Logger = new LoggerConfiguration().
    ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Services.AddSerilog();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    await RoleSeedor.SeedAsync(roleManager);
    await UserSeedor.SeedAsync(userManager);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  

    
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseCors(cors);
app.UseStaticFiles();
app.MapControllers();

app.Run();
