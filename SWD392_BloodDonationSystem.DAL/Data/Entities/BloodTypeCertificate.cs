using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("BloodTypeCertificate")]
public partial class BloodTypeCertificate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CertificateID { get; set; }

    public int UserID { get; set; }

    public int? ImageProof { get; set; }

    public int? CitizenID { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Address { get; set; }

    [StringLength(100)]
    public string BloodDonationCenter { get; set; }

    public int? DonatedVolumn { get; set; }

    public int? SeriNumber { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("BloodTypeCertificates")]
    public virtual User User { get; set; }
}
