using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("BloodDonation")]
public partial class BloodDonation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DonationID { get; set; }

    public int UserID { get; set; }

    public int BloodGroupID { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime DonationDate { get; set; }

    public int? RedCellUnit { get; set; }

    public int? PlasmaUnit { get; set; }

    public int? PlateletUnit { get; set; }

    public int? FullBloodUnit { get; set; }

    [StringLength(20)]
    public string DonationType { get; set; }

    public string Location { get; set; }

    [StringLength(20)]
    public string Status { get; set; }

    public string Note { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("BloodGroupID")]
    [InverseProperty("BloodDonations")]
    public virtual BloodGroup BloodGroup { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("BloodDonations")]
    public virtual User User { get; set; }
}
