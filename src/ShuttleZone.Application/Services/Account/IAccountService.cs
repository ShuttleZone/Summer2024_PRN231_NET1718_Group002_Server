using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Application.Services.Account;

[AutoRegister]
public interface IAccountService
{ 
    Task<RegisterDto> Register(RegisterDto registerDto);
}