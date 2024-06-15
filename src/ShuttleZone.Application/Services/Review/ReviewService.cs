using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;

namespace ShuttleZone.Application.DependencyInjection.Services.Review;
[AutoRegister]

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public ReviewService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    public async Task<bool> DtoCreateReview(DtoCreateReview dtoCreateReview, Guid userId)
    {
        var review = _mapper.Map<Domain.Entities.Review>(dtoCreateReview);
        if (review != null)
        {
            var user = _userManager.Users.First(c => c.Id == userId);
            review.ReviewerId = userId;
            review.CreatedBy = user.Fullname;
            await _unitOfWork.ReviewRepository.AddAsync(review);
            var addSuccess = await _unitOfWork.Complete();
            return addSuccess;
        }
        return false;
    }
}