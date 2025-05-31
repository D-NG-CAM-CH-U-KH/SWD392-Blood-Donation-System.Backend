namespace SWD392_BloodDonationSystem.DAL.Data.RequestDTO.AvailableDonateDate;

public class AvailableDonateDateDTO
{
    public int UserID{ get; set; }
    public DateTime ScheduledDate { get; set; }
    public bool AcceptEmergency { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}