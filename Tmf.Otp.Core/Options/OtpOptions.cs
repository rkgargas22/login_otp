namespace Tmf.Otp.Core.Options;

public class OtpOptions
{
    public const string Otp = "Otp";
    public string AuthType { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public UrlType? Url { get; set; }
}

public class UrlType
{
    public Url? ProductionUrl { get; set; }
    public Url? UatUrl { get; set; }
}

public class Url
{
    public string SendOtp { get; set; } = string.Empty;
    public string VerifyOtp { get; set; } = string.Empty;
}
