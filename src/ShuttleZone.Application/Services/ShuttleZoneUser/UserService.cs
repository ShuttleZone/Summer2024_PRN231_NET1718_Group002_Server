using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.File;
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
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUser user, IUserRepository userRepository, IUnitOfWork unitOfWork, SignInManager<User> signInManager, UserManager<User> userManager, IFileService fileService)
    {
        _user = user;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
        _userManager = userManager;
        _fileService = fileService;
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

    public async Task UploadNewAvatar(IFormFile file)
    {
        var list = new List<IFormFile>();
        list.Add(file);
        var imageUrl = (await _fileService.UploadMultipleFileAsync(list)).FirstOrDefault();
        var user = await _userRepository.GetAsync(x => x.Id.ToString() == _user.Id) ?? throw new Exception("Not Found User.");
        user.ProfilePic = imageUrl;
        _userRepository.Update(user);
        await _unitOfWork.CompleteAsync();
    }
}