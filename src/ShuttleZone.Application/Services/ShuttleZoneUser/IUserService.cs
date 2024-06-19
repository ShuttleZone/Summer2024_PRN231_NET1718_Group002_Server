using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;
using ShuttleZone.Domain.WebResponses.ShuttleZoneUser;

namespace ShuttleZone.Application.Services.ShuttleZoneUser;

public interface IUserService
{
    DtoUserProfile GetUserProfileInformation();
    void UpdateUserProfile(UpdateProfileRequest request);
}