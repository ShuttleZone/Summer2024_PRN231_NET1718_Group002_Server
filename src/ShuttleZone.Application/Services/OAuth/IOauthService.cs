using ShuttleZone.Domain.WebRequests.Auth;

namespace ShuttleZone.Application.Services.OAuth;

public interface IOauthService
{
    Task<OAuthResponse> LoginAsync(OAuthRequest request);
}

public class OAuthResponse
{
    public string AccessToken { get; set; } = "";
    public string RefreshToken { get; set; } = "";
}