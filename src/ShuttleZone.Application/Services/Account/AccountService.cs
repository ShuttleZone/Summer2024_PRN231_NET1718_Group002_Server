using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.Email;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.DependencyInjection.Repositories.User;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Account;
using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;

namespace ShuttleZone.Application.Services.Account;

[AutoRegister]
public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;
    private readonly IUser _currentUser;
    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;

    public AccountService(UserManager<User> userManager, 
        ITokenService tokenService, 
        SignInManager<User> signInManager, 
        IUser currentUser,
        IEmailService emailService, IClubRepository clubRepository, IUserRepository userRepository)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _currentUser = currentUser;
        _emailService = emailService;
        _userRepository = userRepository;
    }
    
    public async Task<NewAccountDto?> Register(RegisterDto registerDto)
    {
        var appUser = new User
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            Fullname = registerDto.Fullname,
            Gender = 0,
            
        };

        var result = await _userManager.CreateAsync(appUser, registerDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        var roleResult = await _userManager.AddToRoleAsync(appUser, "Customer");
       
        if (roleResult.Succeeded)
        {
            var createdAccount =  new NewAccountDto
            {
                Id = appUser.Id,
                Username = appUser.UserName,
                Email = appUser.Email,
                Fullname = appUser.Fullname,
                Token = _tokenService.CreateToken(appUser),
                RefreshToken = ""
            };
        
            /// <summary>
            /// nhi: 21/6/2024 confirm email.
            /// </summary>
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            await _emailService.SendEmailConfirmationAsync(appUser, token);

            return createdAccount;
        }
        else
        {
                await _userManager.DeleteAsync(appUser);
            throw new Exception("Vai trò đăng ký không thành công!");
        }

    }

    public async Task<NewAccountDto> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Account!.ToLower() || u.UserName == loginDto.Account.ToLower());
        if (user == null)
        {
           throw new Exception("Không tìm thấy người dùng!");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false );

        if (!result.Succeeded)
            throw new Exception("Mật khẩu không chính xác!");

        var loginAcc = new NewAccountDto
        {
            Id = user.Id,
            Username = user.UserName,
            Fullname = user.Fullname,
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            RefreshToken = ""
        };

        return loginAcc;

    }

    public async Task ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        HttpException.New()
            .WithStatusCode(401)
            .WithErrorMessage("Bạn chưa đăng nhập!")
            .ThrowIfNull(_currentUser.Id);

        var user = await _userManager.FindByIdAsync(_currentUser.Id.ToString());

        HttpException.New()
            .WithStatusCode(404)
            .WithErrorMessage("Người dùng không tồn tại!")
            .ThrowIfNull(user);

        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        HttpException.New()
            .WithStatusCode(400)
            .WithErrorMessage(result.Errors.FirstOrDefault()?.Description ?? "Đổi mật khẩu không thành công!")
            .ThrowIf(!result.Succeeded);
    }

    public async Task ConfirmEmailAsync(string userId, string token)
    {
        if (userId == null || token == null)
            throw new HttpException(400, "Mã thông báo không hợp lệ");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            throw new HttpException(400, "Người dùng không tồn tại!");

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            throw new HttpException(400, result.Errors.First().Description);
       
    }

    public async Task AssignStaff(AssignStaffRequest request)
    {
        // throw new NotImplementedException();
        var owner = _userRepository.Find(x => x.Id.ToString() == _currentUser.Id).Include(x => x.Clubs).FirstOrDefault() ??
                    throw new HttpException(404, "Người dùng không tồn tại!");
        var club = owner.Clubs.FirstOrDefault(x => x.Id == request.ClubId) ??
                   throw new HttpException(404, $"Người dùng không có quyền thêm nhân viên vào câu lạc bộ {request.ClubId}");
        var isExistAccount = (await _userRepository.GetAllAsync()).Any(x => x.Email == request.Email);
        if (isExistAccount)
            throw new HttpException(400, $"Tài khoản với email {request.Email} đã tồn tại.");
        var staff = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Fullname = request.FullName,
            Gender = request.Gender,
            ClubId = request.ClubId,
            EmailConfirmed = true
        };
        var result = await _userManager.CreateAsync(staff, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
        await _userManager.AddToRoleAsync(staff, "Staff");
    }
}
