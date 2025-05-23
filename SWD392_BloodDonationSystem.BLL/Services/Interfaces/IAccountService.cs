using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.RequestDTO.Accounts;
using SWD392_BloodDonationSystem.DAL.Data.ResponseDTO.Accounts;

namespace SWD392_BloodDonationSystem.BLL.Services.Interfaces;

public interface IAccountService
{
    Task<AccountEntity> GetAccount();
    Task<GetAccountResponseDTO> GetCurrentAccount();
    Task<ICollection<GetAccountResponseDTO>> GetManyAccounts(int pageNumber, int pageSize);
    Task<GetAccountResponseDTO> GetAccountById(Guid id);
    Task<GetAccountResponseDTO> CreateAccount(CreateAccountRequestDTO requestDto);
    Task<GetAccountResponseDTO> UpdateAccount(Guid id, UpdateAccountRequestDTO requestDto);
    Task<bool> DeleteAccount(Guid id);
}