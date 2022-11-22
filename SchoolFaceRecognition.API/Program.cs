using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolFaceRecognition.API.Configurations.Extentions;
using SchoolFaceRecognition.BL.AutoFac;
using SchoolFaceRecognition.BL.AutoMappers;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.Core.DTOs.Config;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.DAL.AutoFac;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile<DtoMappings>();
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(opt =>
    {
        opt.RegisterModule<RepoModule>();
        opt.RegisterModule<ServiceModule>();
    });

builder.Services.Configure<TokenOptionDto>(builder.Configuration.GetSection("TokenOption"));
builder.Services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    TokenOptionDto tokenOption = builder.Configuration.GetSection("TokenOption").Get<TokenOptionDto>();

    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience.First(),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey)),
        ClockSkew = TimeSpan.Zero,
    };

    opt.Events = new JwtBearerEvents()
    {
        OnChallenge =  context =>
        {
            context.HandleResponse();

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";

            ErrorResponse response = new(HttpStatusCode.Unauthorized, ConstantLiterals.UserIsNotAuthorizedMessage);

            string errorMessages = JsonSerializer.Serialize(response);

            // Add some extra context for expired tokens.
            if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
            {
                var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
                context.Response.Headers.Add("x-token-expired", authenticationException.Expires.ToString("o"));
                context.ErrorDescription = $"The token expired on {authenticationException.Expires.ToString("o")}";
            }

            return context.Response.WriteAsync(errorMessages);
        },
    };
});

builder.Services.AddAuthentication();

builder.Services.AddRouting(opt =>
{
    opt.LowercaseUrls = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Description = "Developed by Nijat Abdullaev",
        Title = "School Face Recognition"
    });

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme()
            {
               Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                },
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAppExceptionHandler();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
