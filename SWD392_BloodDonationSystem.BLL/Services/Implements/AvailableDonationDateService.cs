using Microsoft.Extensions.Logging;
using SWD392_BloodDonationSystem.BLL.Services.Interfaces;
using SWD392_BloodDonationSystem.DAL.Context;
using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.Repositories.Interfaces;
using SWD392_BloodDonationSystem.DAL.Data.RequestDTO.AvailableDonateDate;

namespace SWD392_BloodDonationSystem.BLL.Services.Implements;

public class AvailableDonationDateService(
    IUnitOfWork<AppDbContext> unitOfWork,
    ILogger<AvailableDonationDateService> logger) : BaseService<AvailableDonationDateService>(unitOfWork, logger),
    IAvailableDonationDateService
{
    private async Task<bool> CheckValidUser(AvailableDonateDateDTO dto)
    {
        var user = await unitOfWork.GetRepository<User>().FirstOrDefaultAsync(u => u.UserID == dto.UserID, null, null);
        return user is not null;
    }

   //public async Task<bool> CheckDuplicateDate(AvailableDonateDateDTO dto)
//{
  //  var duplicate = await unitOfWork.GetRepository<AvailableDonateDate>().FirstOrDefaultAsync(
  //      predicate: u => 
  //          u.ScheduledDay == dto.ScheduledDay && 
  //          u.ScheduledMonth == dto.ScheduledMonth && 
  //          u.ScheduledYear == dto.ScheduledYear &&
  //      orderBy: null,
  //      include: null
  //  );
  //  return duplicate != null;
//}

    
    public async Task<AvailableDonateDate?> CreateAvailableDonateDate(AvailableDonateDateDTO dto)
    {
       // Check valid user
       if (!await CheckValidUser(dto))
       {
           _logger.LogWarning("User not exist!");
           return null;
       }

       // Check duplicate date
    //   if (await CheckDuplicateDate(dto))
    //   {
    //       _logger.LogWarning("Duplicate date!");
    //       return null;
    //   }
       
        var newDate = new AvailableDonateDate
        {
            UserID = dto.UserID,
            ScheduledDate = dto.ScheduledDate,
            AcceptEmergency = dto.AcceptEmergency,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        var isCreated = await unitOfWork.GetRepository<AvailableDonateDate>().InsertAsyncSuccessfully(newDate);
        return isCreated ? newDate : null;
    }
}