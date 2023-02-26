namespace Tmf.Otp.Core.Constants;

public class ValidationMessages
{
    public const string GeneralValidationErrorMessage = "One or more erros in request data validation.";
    public const string ErrorInRequest = "Error in request.";

    #region header
    public const string BpNoHeader = "Please add BpNo in request header.";
    public const string UserTypeHeader = "Please add UserType in request header.";
    public const string OtpTypeHeader = "Please add OtpType in request header.";
    #endregion

    #region Content/Type
    public const string ApplicationJson = "application/json";
    #endregion

    public const string MobileNumber = "Enter Valid Mobile Number";
    public const string Module = "Enter Valid Module";
    public const string OTP = "Enter Valid OTP";
    public const string Id = "Enter Valid Request Id";
}
