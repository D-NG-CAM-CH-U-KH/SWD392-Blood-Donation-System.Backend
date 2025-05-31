using Microsoft.EntityFrameworkCore;
using SWD392_BloodDonationSystem.DAL.Data.Entities;

namespace SWD392_BloodDonationSystem.DAL.Data.Repositories;

public class AvailableDonationDateRepository : GenericRepository<AvailableDonateDate>
{
    public AvailableDonationDateRepository(DbContext dbContext) : base(dbContext)
    {
        
    }
}