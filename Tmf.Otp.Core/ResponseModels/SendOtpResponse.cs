using System.Text.Json.Serialization;

namespace Tmf.Otp.Core.ResponseModels;

public class SendOtpResponse
{
    [JsonPropertyName("status_code")] 
    public int StatusCode { get; set; }
    [JsonPropertyName("data")] 
    public string Data { get; set; } = string.Empty;
}
