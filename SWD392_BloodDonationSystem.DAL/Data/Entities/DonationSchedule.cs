using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("DonationSchedule")]
public partial class DonationSchedule
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DonationTime { get; set; }

    [Required]
    [StringLength(20)]
    public string WeekDay { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    [StringLength(255)]
    public string Note { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("DonationSchedules")]
    public virtual User CreatedByNavigation { get; set; }

    [InverseProperty("DonationSchedule")]
    public virtual ICollection<DonationAppointment> DonationAppointments { get; set; } = new List<DonationAppointment>();
}
