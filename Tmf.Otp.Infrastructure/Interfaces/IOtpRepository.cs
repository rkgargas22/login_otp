using Tmf.Otp.Core.ResponseModels;
using Tmf.Otp.Infrastructure.Models;

namespace Tmf.Otp.Infrastructure.Interfaces;

public interface IOtpRepository
{
    Task<SendOtpResponse> SendOtp(SendOtpModel sendOtpModel);
    Task<VerifyOtpResponse> VerifyOtp(VerifyOtpModel verifyOtpModel);
}
