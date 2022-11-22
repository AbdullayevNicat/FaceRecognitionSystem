using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolFaceRecognition.Core.DTOs.Auths;
using System.Text;

namespace SchoolFaceRecognition.API.Configurations.Extentions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(opt =>
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

            return serviceCollection;
        }

        public static IServiceCollection AddAuthenticationExtension(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                TokenOptionDto tokenOption = configuration.GetSection("TokenOption").Get<TokenOptionDto>();

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
            });


            return serviceCollection;
        }
    }
}
