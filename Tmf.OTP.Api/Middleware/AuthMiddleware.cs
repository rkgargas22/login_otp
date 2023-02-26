using System.Text.Json;
using Tmf.Otp.Core.Constants;
using Tmf.Otp.Core.Exception;

namespace Tmf.Otp.Api.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        ErrorMessage errorMessage = new ErrorMessage();
        context.Request.Headers.TryGetValue("BpNo", out var bpNo);
        context.Request.Headers.TryGetValue("UserType", out var userType);
        context.Request.Headers.TryGetValue("OtpType", out var otpType);

        //do the checking
        if (string.IsNullOrEmpty(Convert.ToString(bpNo)))
        {
            errorMessage.Message = ValidationMessages.BpNoHeader;
            var exceptionResult = JsonSerializer.Serialize(errorMessage);
            context.Response.StatusCode = 401;
            context.Response.ContentType = ValidationMessages.ApplicationJson;
            await context.Response.WriteAsync(exceptionResult);
            return;
        }

        if (string.IsNullOrEmpty(Convert.ToString(userType)))
        {
            errorMessage.Message = ValidationMessages.UserTypeHeader;
            var exceptionResult = JsonSerializer.Serialize(errorMessage);
            context.Response.StatusCode = 401;
            context.Response.ContentType = ValidationMessages.ApplicationJson;
            await context.Response.WriteAsync(exceptionResult);
            return;
        }

        if (string.IsNullOrEmpty(Convert.ToString(otpType)))
        {
            errorMessage.Message = ValidationMessages.OtpTypeHeader;
            var exceptionResult = JsonSerializer.Serialize(errorMessage);
            context.Response.StatusCode = 401;
            context.Response.ContentType = ValidationMessages.ApplicationJson;
            await context.Response.WriteAsync(exceptionResult);
            return;
        }
        await _next(context);

    }

}
