using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.Mappers;
using ApiPruebaIntegrity.Middleware;
using ApiPruebaIntegrity.Security.Service;
using ApiPruebaIntegrity.Services;
using ApiPruebaIntegrity.Services.Impl;
using ApiPruebaIntegrity.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationServiceImpl>();
builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
builder.Services.AddScoped<ISessionService, SessionServiceImpl>();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context => ValidationUtil.CreateJsonRespStateInvalid(context);
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<DBContextTest>(o => {

    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper
(
    typeof(CompanyMappingProfile),
    typeof(UserMappingProfile),
    typeof(CustomerMappingProfile),
    typeof(ProductMappingProfile)
);

// Configurar autenticación con JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar autenticación y autorización en la app
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
