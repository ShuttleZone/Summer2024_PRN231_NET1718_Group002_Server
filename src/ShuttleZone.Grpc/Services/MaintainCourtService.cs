using Grpc.Core;
using ShuttleZone.Application.Services.Court;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Grpc.Services;

public class MaintainCourtService : Grpc.MaintainCourtService.MaintainCourtServiceBase
{
    private readonly ICourtRepository _courtRepository;
    
    public MaintainCourtService(ICourtRepository courtRepository)
    {
        _courtRepository = courtRepository;
    }
    public override Task<MaintainCourtResponse> Maintain(MaintainCourtRequest request, ServerCallContext context)
    {
        var courtId = Guid.Parse(request.CourtId);
        var court = _courtRepository.GetAll().FirstOrDefault(c => c.Id == courtId);
    
        if (court == null) throw new HttpException(404,$"Không tìm thấy sân {courtId}");
        // if (court.CourtStatus != CourtStatus.Available) throw new HttpException(409, $"Không thể bảo trì sân này vì sân vẫn chưa được hoạt động");
        court.CourtStatus = CourtStatus.Maintain;
        court.LastModified = DateTime.Now;
        _courtRepository.Update(court);

        return Task.FromResult(new MaintainCourtResponse()
        {
            Response = true
        });
    }
}

