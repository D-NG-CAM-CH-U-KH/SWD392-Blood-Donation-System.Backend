
using SWD392_BloodDonationSystem.DAL.Data.RequestDto.Auth;

namespace SWD392_BloodDonationSystem.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<string> HandleLogin(LoginRequestDTO loginRequestDto);
}