using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Common.Settings
{
    [ApplicationSetting]
    public class VNPaySettings
    {
        public string TmnCode { get; set; } = string.Empty;
        public string HashSecret { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string ApiUrl { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public string Locale { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;

    }
}
