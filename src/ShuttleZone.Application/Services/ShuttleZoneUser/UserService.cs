using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.DependencyInjection.Repositories.User;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;
using ShuttleZone.Domain.WebResponses.ShuttleZoneUser;

namespace ShuttleZone.Application.Services.ShuttleZoneUser;
[AutoRegister]
public class UserService : IUserService
{
    private readonly IUser _user;
    private readonly IUserRepository _userRepository;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUser user, IUserRepository userRepository, IUnitOfWork unitOfWork, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _user = user;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public DtoUserProfile GetUserProfileInformation()
    {
        var user =  _userRepository.GetAll().Where(x => x.Id.ToString() == _user.Id)
                .Include(x => x.UserContests)
                .Include(x => x.Reservations)
                .Include(x => x.Wallet)
                .FirstOrDefault()
            ?? throw new Exception("User Not Found");
        var totalReservation = user.Reservations.Count;
        var totalWinContest = user.UserContests.Select(x => x.isWinner).Count();

        var dto = new DtoUserProfile
        {
            Id = user.Id,
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            Fullname = user.Fullname ?? string.Empty,
            PhoneNumber = user.PhoneNumber,
            ProfileImage = "",
            TotalReservation = totalReservation,
            TotalWinContest = totalWinContest,
            Gender = user.Gender
        };
        if(user.Wallet != null)
        {
            dto.Balance = user.Wallet.Balance;
        }
        
        return dto;
    }

    public void UpdateUserProfile(UpdateProfileRequest request)
    {
        var existingUser = _userRepository.GetAll().FirstOrDefault(x => x.Id.ToString() == _user.Id)
            ?? throw new Exception();
        existingUser.Fullname = request.FullName ?? existingUser.Fullname;
        existingUser.PhoneNumber = request.PhoneNumber ?? existingUser.PhoneNumber;
        existingUser.Gender = request.Gender;
        _userRepository.Update(existingUser);
        _unitOfWork.CompleteAsync();
    }
}