using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.Court;

public interface ICourtService
{
    IQueryable<DtoCourtResponse> GetAllCourts();

    DtoCourtResponse GetCourtById(Guid key);
}
