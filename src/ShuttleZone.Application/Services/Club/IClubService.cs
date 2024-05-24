using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses;

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
    /// <returns>A <see cref="IQueryable{T}"/> of <see cref="Club"/>.</returns>
    IQueryable<DtoClubResponse> GetClubs();
}
