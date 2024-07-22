﻿using System.IdentityModel.Tokens.Jwt;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShuttleZone.Application.Services.Email;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Constants;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.Common.Extensions;
using ShuttleZone.Common.Helpers;
using ShuttleZone.Common.Settings;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Auth;
using ShuttleZone.Domain.WebResponses.Auth;

namespace ShuttleZone.Application.Services.OAuth;
[AutoRegister]
public class GoogleOauthService : IGoogleOauthService    
{
    private readonly UserManager<User> _userManager;
    private readonly GoogleSetting _googleSetting;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _jwtService;
    private readonly IMapper _mapper;

    public GoogleOauthService(UserManager<User> userManager, IConfiguration configuration, IEmailService emailService, IUnitOfWork unitOfWork, ITokenService jwtService, IMapper mapper)
    {
        _userManager = userManager;
        _configuration = configuration;
        _emailService = emailService;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _mapper = mapper;
        _googleSetting = _configuration.GetSection(nameof(GoogleSetting)).Get<GoogleSetting>() ??
                         throw new HttpException(500,"Missing google setting.");
    }

    public async Task<OAuthResponse> LoginAsync(OAuthRequest request)
{
    var googleLoginRequest = (GoogleAuthRequest)request;
    var client = new HttpClient();
    var code = WebUtility.UrlDecode(googleLoginRequest.Code);

    var requestParams = new Dictionary<string, string>()
    {
        { GoogleOauthConstant.CODE, code },
        { GoogleOauthConstant.CLIENT_ID, _googleSetting.ClientId },
        { GoogleOauthConstant.CLIENT_SECRET, _googleSetting.ClientSecret },
        { GoogleOauthConstant.REDIRECT_URI, _googleSetting.RedirectUri },
        { GoogleOauthConstant.GRANT_TYPE, GoogleOauthConstant.AUTHORIZATION_CODE }
    };

    var content = new FormUrlEncodedContent(requestParams);
    var response = await client.PostAsync(GoogleOauthConstant.GOOGLE_TOKEN_URL, content);
    if (!response.IsSuccessStatusCode)
        throw new HttpException(404,"Invalid token");
    var authObject = JsonConvert.DeserializeObject<GoogleAuthResponse>(await response.Content.ReadAsStringAsync());

    if (authObject?.IdToken == null)
        throw new Exception("Cannot get id token from Google");

    var handler = new JwtSecurityTokenHandler();
    var securityToken = handler.ReadJwtToken(authObject.IdToken);
    securityToken.Claims.TryGetValue(GoogleTokenClaimConstants.EMAIL, out var email);
    securityToken.Claims.TryGetValue(GoogleTokenClaimConstants.EMAIL_VERIFIED, out var emailVerified);
    securityToken.Claims.TryGetValue(GoogleTokenClaimConstants.GIVEN_NAME, out var name);
    securityToken.Claims.TryGetValue(GoogleTokenClaimConstants.PICTURE, out var picture);

    var user = await _userManager.FindByEmailAsync(email) ?? await CreateNewUserAsync(email, emailVerified, name, picture);
    var authResponse = new OAuthResponse()
    {
        
            AccessToken = _jwtService.CreateToken(user),
            RefreshToken = _jwtService.CreateRefreshToken(),
    };
    return authResponse;
}

    private async Task<User> CreateNewUserAsync(string email, string emailVerified, string fullName, string picture)
    {
        var user = new User
        {
            Fullname = fullName,
            Gender = 0
        };
        user.Email = email;
        user.EmailConfirmed = true;
        user.UserName = email;
        user.NormalizedEmail = email.Normalize();
        user.NormalizedUserName = email.Normalize();
        var autoGeneratedPassword = RandomPasswordHelper.GenerateRandomPassword(10);
        var result = await _userManager.CreateAsync(user, autoGeneratedPassword);
        if (!result.Succeeded)
        {
            throw new Exception("Failed to create user");
        }

        var roleResult = await _userManager.AddToRoleAsync(user, "Customer");

        if (!roleResult.Succeeded)
        {
            throw new Exception("Failed to add role to user");
        }
        return await _userManager.FindByEmailAsync(email) ?? throw new Exception("Cannot find user by email");
    }
}