using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("Report")]
public partial class Report
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportID { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [StringLength(100)]
    public string ReportType { get; set; }

    public int GeneratedBy { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public bool? IsPublic { get; set; }

    [StringLength(255)]
    public string FileUrl { get; set; }

    public string Note { get; set; }

    [ForeignKey("GeneratedBy")]
    [InverseProperty("Reports")]
    public virtual User GeneratedByNavigation { get; set; }
}
