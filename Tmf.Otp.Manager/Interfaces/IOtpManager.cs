using Tmf.Otp.Core.RequestModels;
using Tmf.Otp.Core.ResponseModels;

namespace Tmf.Otp.Manager.Interfaces;

public interface IOtpManager
{
    Task<SendOtpResponse> SendOtp(SendOtpRequest sendOtpRequest);
    Task<VerifyOtpResponse> VerifyOtp(VerifyOtpRequest verifyOtpRequest);
}
