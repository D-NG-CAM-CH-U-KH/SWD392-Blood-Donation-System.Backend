using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("AvailableDonateDate")]
public class AvailableDonateDate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AvailableDateID { get; set; }
    
    [ForeignKey("UserID")]
    [Column("UserID")]
    public int UserID{ get; set; }
    
    [InverseProperty("AvailableDonateDates")]
    public User User { get; set; }
    
    public DateTime ScheduledDate { get; set; }
    
    public bool AcceptEmergency { get; set; }
    
    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }
    
    [Column(TypeName = "timestamp with time zone")]
    public DateTime UpdatedAt { get; set; }
}