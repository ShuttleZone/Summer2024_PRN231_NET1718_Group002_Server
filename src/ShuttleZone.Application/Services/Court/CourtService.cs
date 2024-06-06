﻿using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses.Court;
using CourtEntity = ShuttleZone.Domain.Entities.Court;

namespace ShuttleZone.Application.Services.Court;

[AutoRegister]
public class CourtService : ICourtService
{
    private readonly ICourtRepository _courtRepository;
    private readonly IClubRepository _clubRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourtService(
        ICourtRepository courtRepository,
        IClubRepository clubRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _courtRepository = courtRepository;
        _clubRepository = clubRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DtoCourtResponse> CreateCourtAsync(CreateCourtRequest request, CancellationToken cancellationToken)
    {
        var clubExists = await _clubRepository.ExistsAsync(x => x.Id == request.ClubId, cancellationToken);
        if (!clubExists)
            throw new Exception("Club does not exist");

        var court = _mapper.Map<CourtEntity>(request);
        court.Created = DateTime.Now;
        court.CreatedBy = "Admin";
        court.LastModified = DateTime.Now;
        await _courtRepository.AddAsync(court, cancellationToken);
        await _unitOfWork.Complete(cancellationToken);

        var createdCourt = await _courtRepository.Find(x => x.Id == court.Id)
            .ProjectTo<DtoCourtResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        ArgumentNullException.ThrowIfNull(createdCourt, "Court not created");

        return createdCourt;
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