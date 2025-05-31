using Microsoft.EntityFrameworkCore;
using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.Repositories.Interfaces;

namespace SWD392_BloodDonationSystem.DAL.Data.Repositories;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    
}