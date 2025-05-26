using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("DonationAppointment")]
public partial class DonationAppointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AppointmentID { get; set; }

    public int UserID { get; set; }

    public int? UserFormID { get; set; }

    public int DonationScheduleID { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime ScheduledDate { get; set; }

    [StringLength(20)]
    public string Status { get; set; }

    public string Location { get; set; }

    public string Note { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("DonationScheduleID")]
    [InverseProperty("DonationAppointments")]
    public virtual DonationSchedule DonationSchedule { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("DonationAppointments")]
    public virtual User User { get; set; }
}
