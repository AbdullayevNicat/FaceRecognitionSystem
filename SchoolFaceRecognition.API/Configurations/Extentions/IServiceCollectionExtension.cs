using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolFaceRecognition.BL.AutoMappers;
using SchoolFaceRecognition.Core.DTOs.Auth;
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

        public static IServiceCollection AddMappers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(opt => { 
             
                 opt.AddProfile<DtoMappings>();
            });

            return serviceCollection;
        }

        public static IServiceCollection AddOptionPatterns(this IServiceCollection serviceCollection,
                                                           IConfiguration configuration)
        {
            serviceCollection.Configure<TokenOptionDto>(configuration.GetSection("TokenOption"));

            return serviceCollection;
        }

        public static IServiceCollection AddJwtConfigs(this IServiceCollection serviceCollection,
                                                           IConfiguration configuration)
        {
            TokenOptionDto tokenOptionDto = configuration.GetSection("TokenOption").Get<TokenOptionDto>();

            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = tokenOptionDto.Issuer,
                    ValidAudience = tokenOptionDto.Audiences.First(),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptionDto.SecurityKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime= true,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            return serviceCollection;
        }

        public static IServiceCollection AddRedis(this IServiceCollection serviceCollection,
                                                           IConfiguration configuration)
        {
            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("Redis").Value;
            });

            serviceCollection.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());

            return serviceCollection;
        }
    }
}
