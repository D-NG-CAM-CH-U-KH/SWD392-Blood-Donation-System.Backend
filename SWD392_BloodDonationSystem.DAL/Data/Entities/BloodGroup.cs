using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("BloodGroup")]
public partial class BloodGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BloodGroupID { get; set; }

    [Required]
    [StringLength(3)]
    public string BloodType { get; set; }

    [StringLength(255)]
    public string Description { get; set; }

    [StringLength(50)]
    public string CanDonateTo { get; set; }

    [StringLength(50)]
    public string CanReceiveFrom { get; set; }

    [InverseProperty("BloodGroup")]
    public virtual ICollection<BloodDonation> BloodDonations { get; set; } = new List<BloodDonation>();

    [InverseProperty("BloodGroup")]
    public virtual ICollection<BloodRequest> BloodRequests { get; set; } = new List<BloodRequest>();

    [InverseProperty("BloodGroup")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
