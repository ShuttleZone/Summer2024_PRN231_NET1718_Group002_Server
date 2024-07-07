using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Review;

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
            var addSuccess = await _unitOfWork.CompleteAsync();
            return addSuccess;
        }
        return false;
    }

    public async Task<bool> DtoReplyReview(DtoReplyReview dtoReplyReview, Guid replyer)
    {
        // var reply = _mapper.Map<Domain.Entities.Review>(dtoReplyReview);
        var updateReview = _unitOfWork.ReviewRepository.Find(c => c.Id == dtoReplyReview.Id).FirstOrDefault();
        if (updateReview != null)
        {
            var user = _userManager.Users.First(c => c.Id == replyer);
            updateReview.ReplyTitle = dtoReplyReview.ReplyTitle;
            updateReview.ReplyContent = dtoReplyReview.ReplyContent;
            updateReview.ReplyPerson = user.Fullname;
            updateReview.ReplyTime = DateTime.Now;
            updateReview.LastModified = DateTime.Now;
            updateReview.LastModifiedBy = user.Fullname;
             _unitOfWork.ReviewRepository.Update(updateReview);
            var addSuccess = await _unitOfWork.CompleteAsync();
            return addSuccess;
        }
        return false;
    }

    public IQueryable<DtoReviewsResponse> GetReviews()
    {
        var reviewQueryable = _unitOfWork.ReviewRepository.GetAll();
            var dtoReturn = reviewQueryable.ProjectTo<DtoReviewsResponse>(_mapper.ConfigurationProvider);
            return dtoReturn;
    }

    public IQueryable<DtoReviewsResponse> GetReviewByClubId(Guid clubId)
    {
        var reviewQuery = _unitOfWork.ReviewRepository.Find(c => c.ClubId == clubId)
            .Include(r => r.Club)
            .Include(r => r.Reviewer)
            .ProjectTo<DtoReviewsResponse>(_mapper.ConfigurationProvider);

        return reviewQuery;
    }
}
