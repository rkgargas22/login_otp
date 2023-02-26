using FluentValidation;
using Tmf.Otp.Core.Constants;
using Tmf.Otp.Core.RequestModels;

namespace Tmf.Otp.Api.Validations;

public class VerifyOtpValidator : AbstractValidator<VerifyOtpRequest>
{
    public VerifyOtpValidator()
    {
        RuleFor(x => x.Otp).NotEmpty().WithMessage(ValidationMessages.OTP);
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.Id);
    }
}
