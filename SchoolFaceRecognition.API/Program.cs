using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SchoolFaceRecognition.API.Configurations.Extentions;
using SchoolFaceRecognition.API.Configurations.Helpers;

const string ORIGIN_POLICY_NAME = "school_origin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(
        new RouteTokenTransformerConvention(
            new SlugifyParameterTransformer()));
});

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

builder.Services.AddTransient<ProblemDetailsFactory, CustomProblemDetailsFactory>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: ORIGIN_POLICY_NAME, op =>
    {
        op.AllowAnyOrigin()
            .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAppExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ORIGIN_POLICY_NAME);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
