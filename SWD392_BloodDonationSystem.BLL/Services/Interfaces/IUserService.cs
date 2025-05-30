using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.RequestDTO.Accounts;
using SWD392_BloodDonationSystem.DAL.Data.ResponseDTO.Accounts;

namespace SWD392_BloodDonationSystem.BLL.Services.Interfaces;

public interface IUserService
{
    Task<User?> HandleCreateUser(CreateAccountRequestDTO accountRequestDto);
    
}