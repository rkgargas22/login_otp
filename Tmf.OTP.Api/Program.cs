using FluentValidation;
using Tmf.Logs;
using Tmf.Otp.Api.Middleware;
using Tmf.Otp.Api.Validations;
using Tmf.Otp.Core.Options;
using Tmf.Otp.Core.RequestModels;
using Tmf.Otp.Infrastructure.HttpServices;
using Tmf.Otp.Infrastructure.Interfaces;
using Tmf.Otp.Infrastructure.Services;
using Tmf.Otp.Manager.Interfaces;
using Tmf.Otp.Manager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.Configure<OtpOptions>(builder.Configuration.GetSection(OtpOptions.Otp));
builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHttpService, HttpService>();

builder.Services.AddScoped<IOtpRepository, OtpRepository>();

builder.Services.AddScoped<IOtpManager, OtpManager>();

builder.Services.AddScoped<IValidator<SendOtpRequest>, SendOtpValidator>();
builder.Services.AddScoped<IValidator<VerifyOtpRequest>, VerifyOtpValidator>();

builder.Services.AddSingleton<ILog, Log>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
