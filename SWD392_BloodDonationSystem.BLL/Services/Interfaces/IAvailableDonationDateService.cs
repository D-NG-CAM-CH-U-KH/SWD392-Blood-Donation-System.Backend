using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.RequestDTO.AvailableDonateDate;

namespace SWD392_BloodDonationSystem.BLL.Services.Interfaces;

public interface IAvailableDonationDateService
{
    Task<AvailableDonateDate?> CreateAvailableDonateDate(AvailableDonateDateDTO dto);
}