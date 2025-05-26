using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("Reminder")]
public partial class Reminder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReminderID { get; set; }

    public int UserID { get; set; }

    public DateOnly? LastDonationDate { get; set; }

    public DateOnly? NextEligibleDate { get; set; }

    public bool? IsSent { get; set; }

    [StringLength(20)]
    public string ReminderType { get; set; }

    public string Note { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime? SentAt { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("Reminders")]
    public virtual User User { get; set; }
}
