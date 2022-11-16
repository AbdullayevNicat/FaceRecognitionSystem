using Autofac;
using Autofac.Extensions.DependencyInjection;
using SchoolFaceRecognition.API.Configurations.Extentions;
using SchoolFaceRecognition.BL.AutoFac;
using SchoolFaceRecognition.BL.AutoMappers;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.Core.DTOs.Config;
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAppExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
