using FluentValidation;
using Tmf.Otp.Core.Constants;
using Tmf.Otp.Core.RequestModels;

namespace Tmf.Otp.Api.Validations;

public class SendOtpValidator : AbstractValidator<SendOtpRequest>
{
    public SendOtpValidator()
    {
        RuleFor(x => x.MobileNumber).NotEmpty().Length(10).Matches("^[6-9]\\d{9}$").WithMessage(ValidationMessages.MobileNumber);
        RuleFor(x => x.Module).NotEmpty().WithMessage(ValidationMessages.Module);
    }
}
