using System.Text.Json.Serialization;

namespace Tmf.Otp.Core.RequestModels;

public class VerifyOtpRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; } 
    [JsonPropertyName("otp")]
    public int Otp { get; set; }
}
