using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Tmf.Otp.Core.Constants;
using Tmf.Otp.Core.Exception;
using Tmf.Otp.Core.RequestModels;
using Tmf.Otp.Core.ResponseModels;
using Tmf.Otp.Manager.Interfaces;

namespace Tmf.Otp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OtpController : ControllerBase
{
    private readonly IValidator<SendOtpRequest> _sendOtpValidator;
    private readonly IValidator<VerifyOtpRequest> _verifyOtpValidator;
    private readonly IOtpManager _otpManager;

    public OtpController(IValidator<SendOtpRequest> sendOtpValidator, IValidator<VerifyOtpRequest> verifyOtpValidator, IOtpManager otpManager)
    {
        _sendOtpValidator = sendOtpValidator;
        _verifyOtpValidator = verifyOtpValidator;
        _otpManager = otpManager;
    }

    [HttpPost]
    [Route("SendOtp")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(SendOtpResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> SendOtp([FromBody] SendOtpRequest sendOtpRequest)
    {
        ValidationResult result = await _sendOtpValidator.ValidateAsync(sendOtpRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorMessage { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        var data = await _otpManager.SendOtp(sendOtpRequest);

        return CreatedAtAction(nameof(SendOtp), new { RequestId = data.Data }, data);
    }   

    [HttpPost]
    [Route("VerifyOtp")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(VerifyOtpResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequest verifyOtpRequest)
    {
        ValidationResult result = await _verifyOtpValidator.ValidateAsync(verifyOtpRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorMessage { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        VerifyOtpResponse verifyOtpResponse = await _otpManager.VerifyOtp(verifyOtpRequest);

        if(verifyOtpResponse.StatusCode != 0)
        {
            return BadRequest(new ErrorMessage { Message = "Otp verification failed.", Error = "" });
        }

        return CreatedAtAction(nameof(VerifyOtp), verifyOtpResponse.Data, verifyOtpResponse);
    }
}
