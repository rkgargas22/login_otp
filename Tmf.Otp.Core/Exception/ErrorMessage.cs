using System.Text.Json.Serialization;

namespace Tmf.Otp.Core.Exception;

public class ErrorMessage
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("error")]
    public dynamic Error { get; set; } = string.Empty;
}
