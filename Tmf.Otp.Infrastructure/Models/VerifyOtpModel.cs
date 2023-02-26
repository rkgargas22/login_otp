using System.Text.Json.Serialization;

namespace Tmf.Otp.Infrastructure.Models;

public class VerifyOtpModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("otp")]
    public int Otp { get; set; }
}
