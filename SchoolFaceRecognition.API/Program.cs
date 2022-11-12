using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using SchoolFaceRecognition.BusinessLayer.AutoFac;
using SchoolFaceRecognition.DAL.AutoFac;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

var zad  = assemblies.Where(x => x.FullName.Contains("SchoolFaceRecognition")).ToArray();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(opt =>
    {
        opt.RegisterAssemblyModules(assemblies);
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
