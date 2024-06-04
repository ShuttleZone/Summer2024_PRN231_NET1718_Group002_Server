using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.Court;

[AutoRegister]
public class CourtService : ICourtService
{
    private readonly ICourtRepository _courtRepository;
    private readonly IMapper _mapper;

    public CourtService(ICourtRepository courtRepository, IMapper mapper)
    {
        _courtRepository = courtRepository;
        _mapper = mapper;
    }

    public IQueryable<DtoCourtResponse> GetAllCourts()
    {
        var courts = _courtRepository.GetAll()
            .Include(x => x.Club)
            .Include(x => x.ReservationDetails);
        var dtoCourtResponses =  _mapper.ProjectTo<DtoCourtResponse>(courts);
        return dtoCourtResponses;
    }

    public  DtoCourtResponse GetCourtById(Guid key)
    {
        var court =  _courtRepository.Find(x => x.Id == key)
            .Include(x => x.Club)
            .Include(x => x.ReservationDetails).FirstOrDefault();
        return _mapper.Map<DtoCourtResponse>(court);
    }
}
