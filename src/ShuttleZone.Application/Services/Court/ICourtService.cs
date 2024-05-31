using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.Court;
[AutoRegister]
public interface ICourtService
{
    IQueryable<DtoCourtResponse> GetAllCourts();

    DtoCourtResponse GetCourtById(Guid key);
}