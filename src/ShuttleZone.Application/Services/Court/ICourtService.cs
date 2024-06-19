using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.Court;

public interface ICourtService
{
    IQueryable<DtoCourtResponse> GetAllCourts();

    DtoCourtResponse GetCourtById(Guid key);

    /// <summary>
    /// Create a new court
    /// </summary>
    /// <param name="request">The request to create a new court</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The created court</returns>
    Task<DtoCourtResponse> CreateCourtAsync(CreateCourtRequest request, CancellationToken cancellationToken);

    bool DisableCourt(Guid courtId);
    bool MaintainCourt(Guid courtId);
}
