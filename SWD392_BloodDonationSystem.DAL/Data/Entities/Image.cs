using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("Image")]
public partial class Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ImageID { get; set; }

    [Required]
    [StringLength(255)]
    public string FileName { get; set; }

    [StringLength(100)]
    public string MimeType { get; set; }

    [StringLength(255)]
    public string URL { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime UploadedAt { get; set; }

    public int? UploadedBy { get; set; }

    [ForeignKey("UploadedBy")]
    [InverseProperty("Images")]
    public virtual User UploadedByNavigation { get; set; }
}
