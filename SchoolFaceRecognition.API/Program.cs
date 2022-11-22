using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.API.Configurations.Extentions;
using SchoolFaceRecognition.API.Configurations.Helpers;
using SchoolFaceRecognition.BL.AutoFac;
using SchoolFaceRecognition.BL.AutoMappers;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.Core.DTOs.Config;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.AutoFac;

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
}).AddEntityFrameworkStores<SchoolDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddAuthenticationExtension(builder.Configuration);

builder.Services.AddAuthentication();

builder.Services.AddRouting(opt =>
{
    opt.LowercaseUrls = true;
});

builder.Services.AddControllers(options =>
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExtension();

var app = builder.Build();


app.UseAppExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
