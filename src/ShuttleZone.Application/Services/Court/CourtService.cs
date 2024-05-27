using AutoMapper;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.Court;

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
        var courts = _courtRepository.GetAll();
        var dtoCourtResponses =  _mapper.ProjectTo<DtoCourtResponse>(courts);
        return dtoCourtResponses;
    }
}