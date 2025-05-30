using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SWD392_BloodDonationSystem.BLL.Services.Interfaces;
using SWD392_BloodDonationSystem.DAL.Context;
using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.Repositories;
using SWD392_BloodDonationSystem.DAL.Data.Repositories.Interfaces;
using SWD392_BloodDonationSystem.DAL.Data.RequestDTO.Accounts;
using SWD392_BloodDonationSystem.DAL.Data.RequestDto.Auth;

namespace SWD392_BloodDonationSystem.BLL.Services.Implements;

public class UserService(IUnitOfWork<AppDbContext> unitOfWork, ILogger<UserService> logger) : BaseService<UserService>(unitOfWork, logger), IUserService
{
    private readonly PasswordHasher<object> _passwordHasher = new();

    private async Task<string> CheckDupCreateInfo(CreateAccountRequestDTO dto)
    {
        var existingUser = await unitOfWork.GetRepository<User>().FirstOrDefaultAsync(
            predicate: x =>
                x.Email.Trim().ToLower() == dto.Email.Trim().ToLower() ||
                x.Phone.Trim() == dto.Phone.Trim() ||
                x.CitizenID.Trim() == dto.CitizenID.Trim()
        );

        if (existingUser == null)
        {
            return "";
        }

        var duplicates = new List<string>();

        if (existingUser.Email.Trim().ToLower() == dto.Email.Trim().ToLower())
            duplicates.Add("Email");

        if (existingUser.Phone.Trim() == dto.Phone.Trim())
            duplicates.Add("Phone");

        if (existingUser.CitizenID.Trim() == dto.CitizenID.Trim())
            duplicates.Add("CitizenId");

        return string.Join(", ", duplicates);
    }

    
    public async Task<User?> HandleCreateUser(CreateAccountRequestDTO dto)
    {
        var checkDup = await CheckDupCreateInfo(dto);
        if (!string.IsNullOrEmpty(checkDup))
        {
            throw new InvalidOperationException("An account with the same " + checkDup + " already exists.");
        }
        var newUser = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email.Trim(),
            CitizenID = dto.CitizenID.Trim(),
            Phone = dto.Phone.Trim(),
            Gender = dto.Gender,
            DateOfBirth = dto.DateOfBirth,
            BloodGroupID = dto.BloodGroupID,
            City = dto.City,
            District = dto.District,
            Ward = dto.Ward,
            HouseNumber = dto.HouseNumber,
            Longitude = dto.Longitude,
            Latitude = dto.Latitude,
            IsActive = dto.IsActive,
            CreatedAt = dto.CreatedAt ?? DateTime.Now
        };

        newUser.Password = _passwordHasher.HashPassword(newUser, dto.Password);

        var isCreated = await unitOfWork.GetRepository<User>().InsertAsyncSuccessfully(newUser);
        return isCreated ? newUser : null;
    }


}