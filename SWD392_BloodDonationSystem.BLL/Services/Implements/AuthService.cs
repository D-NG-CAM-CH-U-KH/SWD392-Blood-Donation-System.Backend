using SWD392_BloodDonationSystem.BLL.Helpers;
using SWD392_BloodDonationSystem.BLL.Services.Interfaces;
using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.Repositories.Interfaces;
using SWD392_BloodDonationSystem.DAL.Data.RequestDto.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SWD392_BloodDonationSystem.DAL.Context;

namespace SWD392_BloodDonationSystem.BLL.Services.Implements;

public class AuthService
    (IUnitOfWork<AppDbContext> unitOfWork, ILogger<AuthService> logger,  TokenHelper tokenHelper)
    : BaseService<AuthService>(unitOfWork, logger), IAuthService
{
    private readonly PasswordHasher<object> _passwordHasher = new();

    public async Task<string> HandleLogin(LoginRequestDTO loginRequest)
    {
        // Check if account exists
        var user = await _unitOfWork.GetRepository<User>()
            .FirstOrDefaultAsync(
                predicate: u => u.CitizenID == loginRequest.CitizenID,
                include: u => u.Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                );
        
        if (user == null)
            throw new UnauthorizedAccessException("Invalid email or password");
        
        // Verify password
        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
            throw new UnauthorizedAccessException("Invalid email or password");
        
        return tokenHelper.GenerateToken(user.UserID.ToString(), user.CitizenID, user.Email, user.UserRoles);
    }
}