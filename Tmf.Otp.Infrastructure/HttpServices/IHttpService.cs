using System.Text.Json;

namespace Tmf.Otp.Infrastructure.HttpServices;

public interface IHttpService
{
    Task<JsonDocument> PostAsync(string uri, HttpContent content);
}
