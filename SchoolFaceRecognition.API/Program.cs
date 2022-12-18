using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using SchoolFaceRecognition.API.Configurations.Extentions;
using SchoolFaceRecognition.API.Configurations.Helpers;
using SchoolFaceRecognition.API.SignalR;
using SoapCore;

const string ORIGIN_POLICY_NAME = "school_origin";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(
        new RouteTokenTransformerConvention(
            new SlugifyParameterTransformer()));
});
    //.AddXmlSerializerFormatters();

// Add services to the container.
builder.Services.AddMappers();

builder.Host.AddAutoFac();

builder.Services.AddOptionPatterns(builder.Configuration);

builder.Services.AddRouting(opt =>
{
    opt.LowercaseUrls = true;
    opt.LowercaseQueryStrings = true;
});

builder.Services.AddRedis(builder.Configuration);

builder.Services.AddJwtConfigs(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerExtension();

builder.Services.AddSoapCore();

builder.Services.AddCORSConfig(ORIGIN_POLICY_NAME);

builder.Services.AddServices();

builder.Services.AddSignalR();

builder.Services.AddMediatR(typeof(Program));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAppExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(ORIGIN_POLICY_NAME);

app.MapControllers();

app.UseSOAPEndpoints();

app.MapHub<NotificationHub>("/NotificationHub");

app.Run();
