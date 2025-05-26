using System.Security.Claims;
using SWD392_BloodDonationSystem.DAL.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SWD392_BloodDonationSystem.DAL.Context;

namespace SWD392_BloodDonationSystem.BLL.Services;

public abstract class BaseService<TEntity>
    where TEntity : class
{
    protected readonly IUnitOfWork<AppDbContext> _unitOfWork;
    protected readonly ILogger<TEntity> _logger;
    private readonly IHttpContextAccessor? _httpContextAccessor;

    protected BaseService(IUnitOfWork<AppDbContext> unitOfWork, ILogger<TEntity> logger, IHttpContextAccessor? httpContextAccessor = null)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    protected Guid GetCurrentAccountIdThroughToken()
    {
        var accountIdString = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(accountIdString, out var accountId))
        {
            return accountId;
        }
        throw new UnauthorizedAccessException("Token is invalid");
    }

}