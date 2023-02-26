using Tmf.Otp.Core.RequestModels;
using Tmf.Otp.Core.ResponseModels;
using Tmf.Otp.Infrastructure.Interfaces;
using Tmf.Otp.Infrastructure.Models;
using Tmf.Otp.Manager.Interfaces;

namespace Tmf.Otp.Manager.Services;

public class OtpManager : IOtpManager
{
    private readonly IOtpRepository _otpRepository;
    public OtpManager(IOtpRepository otpRepository)
    {
        _otpRepository = otpRepository;
    }

    public async Task<SendOtpResponse> SendOtp(SendOtpRequest sendOtpRequest)
    {
        SendOtpModel sendOtpModel = new SendOtpModel
        {
            MobileNumber = sendOtpRequest.MobileNumber,
            Module = sendOtpRequest.Module
        };
        return await _otpRepository.SendOtp(sendOtpModel);
    }

    public async Task<VerifyOtpResponse> VerifyOtp(VerifyOtpRequest verifyOtpRequest)
    {
        VerifyOtpModel verifyOtpModel = new VerifyOtpModel
        {
            Id = verifyOtpRequest.Id,
            Otp = verifyOtpRequest.Otp
        };
        return await _otpRepository.VerifyOtp(verifyOtpModel);
    }
}
