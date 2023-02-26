using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using Tmf.Otp.Core.Constants;
using Tmf.Otp.Core.Options;
using Tmf.Otp.Core.ResponseModels;
using Tmf.Otp.Infrastructure.HttpServices;
using Tmf.Otp.Infrastructure.Interfaces;
using Tmf.Otp.Infrastructure.Models;

namespace Tmf.Otp.Infrastructure.Services;

public class OtpRepository : IOtpRepository
{
    private readonly IHttpService _httpService;
    private readonly OtpOptions _options;
    public OtpRepository(IHttpService httpService, IOptions<OtpOptions> options)
    {
        _httpService = httpService;
        _options = options.Value;
    }

    public async Task<SendOtpResponse> SendOtp(SendOtpModel sendOtpModel)
    {
        var result = await _httpService.PostAsync(_options.Url!.ProductionUrl!.SendOtp, new StringContent(JsonSerializer.Serialize(sendOtpModel), Encoding.UTF8, ValidationMessages.ApplicationJson));

        if(result == null)
        {
            return new SendOtpResponse();
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<SendOtpResponse>(result, jsonSerializerOptions)!;
    }

    public async Task<VerifyOtpResponse> VerifyOtp(VerifyOtpModel verifyOtpModel)
    {
        var result = await _httpService.PostAsync(_options.Url!.ProductionUrl!.VerifyOtp, new StringContent(JsonSerializer.Serialize(verifyOtpModel), Encoding.UTF8, ValidationMessages.ApplicationJson));

        if (result == null)
        {
            return new VerifyOtpResponse();
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<VerifyOtpResponse>(result, jsonSerializerOptions)!;
    }
}
