using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("BloodMatchingLog")]
public partial class BloodMatchingLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MatchID { get; set; }

    public int RequestID { get; set; }

    public int DonorID { get; set; }

    public int? AppointmentID { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime? MatchDate { get; set; }

    [StringLength(20)]
    public string MatchType { get; set; }

    [StringLength(20)]
    public string Status { get; set; }

    public string Note { get; set; }

    [ForeignKey("DonorID")]
    [InverseProperty("BloodMatchingLogs")]
    public virtual User Donor { get; set; }

    [ForeignKey("RequestID")]
    [InverseProperty("BloodMatchingLogs")]
    public virtual BloodRequest Request { get; set; }
}
