using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Tmf.Otp.Core.Options;

namespace Tmf.Otp.Infrastructure.HttpServices;

public class HttpService : IHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OtpOptions _options;
    public HttpService(IHttpClientFactory httpClientFactory, IOptions<OtpOptions> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    public async Task<JsonDocument> PostAsync(string uri, HttpContent content)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_options.AuthType, _options.SecretKey);

        HttpResponseMessage response = await httpClient.PostAsync(uri, content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JsonDocument>() ?? throw new ArgumentNullException();
    }
}
