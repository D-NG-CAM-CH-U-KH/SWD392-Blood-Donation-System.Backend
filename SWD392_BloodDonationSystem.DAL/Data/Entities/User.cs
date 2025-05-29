using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("User")]
public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Password { get; set; }

    [Required]
    [StringLength(10)]
    public string CitizenID { get; set; }

    public int? CitizenCardFront { get; set; }

    public int? CitizenCardBack { get; set; }

    [StringLength(20)]
    public string Phone { get; set; }

    public bool Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public int? BloodGroupID { get; set; }

    [StringLength(100)]
    public string City { get; set; }

    [StringLength(100)]
    public string District { get; set; }

    [StringLength(100)]
    public string Ward { get; set; }

    [StringLength(100)]
    public string HouseNumber { get; set; }

    public int? Longitude { get; set; }

    public int? Latitude { get; set; }

    [DefaultValue(false)]
    public bool IsActive { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    [InverseProperty("Author")]
    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    [InverseProperty("User")]
    public virtual ICollection<BloodDonation> BloodDonations { get; set; } = new List<BloodDonation>();

    [ForeignKey("BloodGroupID")]
    [InverseProperty("Users")]
    public virtual BloodGroup BloodGroup { get; set; }

    [InverseProperty("Donor")]
    public virtual ICollection<BloodMatchingLog> BloodMatchingLogs { get; set; } = new List<BloodMatchingLog>();

    [InverseProperty("MatchedDonor")]
    public virtual ICollection<BloodRequest> BloodRequestMatchedDonors { get; set; } = new List<BloodRequest>();

    [InverseProperty("Requester")]
    public virtual ICollection<BloodRequest> BloodRequestRequesters { get; set; } = new List<BloodRequest>();

    [InverseProperty("User")]
    public virtual ICollection<BloodTypeCertificate> BloodTypeCertificates { get; set; } = new List<BloodTypeCertificate>();

    [InverseProperty("User")]
    public virtual ICollection<DonationAppointment> DonationAppointments { get; set; } = new List<DonationAppointment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<DonationSchedule> DonationSchedules { get; set; } = new List<DonationSchedule>();

    [InverseProperty("UploadedByNavigation")]
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    [InverseProperty("User")]
    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

    [InverseProperty("GeneratedByNavigation")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
