using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PFE_API;
using PFE_API.Controller;
using PFE_API.Model;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost",
//        builder => builder
//            .WithOrigins("http://localhost:5173") // Your frontend URL
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials());
//});

builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            //policy.WithOrigins("http://localhost:5173", "https://localhost:7189");
        });
});

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthentication();


//builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql("Server=127.0.0.1; Port=5432; Database=testing;User Id=postgres;Password=abdou0000"));
//builder.Services.AddIdentityCore<AppUser>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddApiEndpoints();


var app = builder.Build();

app.UseCors();

//app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapIdentityApi<AppUser>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


//app.MapGet("verify_token", (string api_token) => "Token is valid").RequireAuthorization(); // Added [Authorize]

app.MapGet("/getEmployees", () => EmployeeDbController.GetEmployees());

app.MapControllers();


app.Run();