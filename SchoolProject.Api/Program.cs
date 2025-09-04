using Data.Entities;
using infrastructure.Data;
using infrastructure.Interface;
using infrastructure.Repositires;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Infrastructure;
using Service;
using Core; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddInfrastructureDependencies().
                 AddServiceDependencies().
                 AddCoreDependencies();

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





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  

    
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(cors);

app.MapControllers();

app.Run();
