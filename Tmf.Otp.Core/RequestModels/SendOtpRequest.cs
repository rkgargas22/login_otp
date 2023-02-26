using System.Text.Json.Serialization;

namespace Tmf.Otp.Core.RequestModels;

public class SendOtpRequest
{
    [JsonPropertyName("mobile_number")] 
    public string MobileNumber { get; set; } = string.Empty;
    [JsonPropertyName("module")] 
    public string Module { get; set; } = string.Empty;
}
