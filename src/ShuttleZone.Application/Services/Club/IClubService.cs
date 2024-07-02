
using ShuttleZone.Domain.WebRequests.Club;
using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;

namespace ShuttleZone.Application.Services;

/// <summary>
/// Handles CRUD operations for clubs.
/// </summary>
public interface IClubService
{
    /// <summary>
    /// Gets a list of clubs.
    /// </summary>
    /// <returns>A <see cref="IQueryable{T}"/> of <see cref="DtoClubResponse"/>.</returns>
    IQueryable<DtoClubResponse> GetClubs();
    
    /// <summary>
    /// Gets a club by its unique identifier.
    /// </summary>
    /// <returns>A <see cref="DtoClubResponse"/>.</returns>
    DtoClubResponse? GetClub(Guid key);

    /// <summary>
    /// Gets a list of clubs that the manager owns.
    /// </summary>
    /// <returns>A <see cref="IQueryable{T}"/> of <see cref="DtoClubResponse"/>.</returns>
    IQueryable<DtoClubResponse> GetMyClubs();

    IQueryable<ClubRequestDetailReponse> GetCreateClubRequests();
    bool AcceptClubRequest(Guid ClubId);
    bool RejectClubRequest(Guid ClubId);

    Task<DtoClubResponse> AddClubAsync(CreateClubRequest request);
    IQueryable<DtoClubStaff> GetMyStaff();
}
