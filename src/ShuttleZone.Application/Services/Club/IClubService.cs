using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;

namespace ShuttleZone.Application.Services;

/// <summary>
/// Handles CRUD operations for clubs.
/// </summary>
[AutoRegister]
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

    IQueryable<CreateClubRequestResponse> GetCreateClubRequests();

    CreateClubRequestDetailReponse? GetClubRequestDetail(Guid clubId);
}
