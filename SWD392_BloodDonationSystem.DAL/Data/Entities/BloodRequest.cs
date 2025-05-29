using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("BloodRequest")]
public partial class BloodRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestID { get; set; }

    public int RequesterID { get; set; }

    public int? MatchedDonorID { get; set; }

    public int BloodGroupID { get; set; }
    
    public int Volume { get; set; }

    [StringLength(20)]
    public string UrgencyLevel { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime NeededDate { get; set; }

    [StringLength(20)]
    public string Status { get; set; }

    public string Location { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("BloodGroupID")]
    [InverseProperty("BloodRequests")]
    public virtual BloodGroup BloodGroup { get; set; }

    [InverseProperty("Request")] 
    public virtual BloodMatchingLog BloodMatchingLog { get; set; }

    [ForeignKey("MatchedDonorID")]
    [InverseProperty("BloodRequestMatchedDonors")]
    public virtual User MatchedDonor { get; set; }

    [ForeignKey("RequesterID")]
    [InverseProperty("BloodRequestRequesters")]
    public virtual User Requester { get; set; }
}
