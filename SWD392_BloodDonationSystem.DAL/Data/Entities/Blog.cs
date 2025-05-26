using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("Blog")]
public partial class Blog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BlogID { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    public string Content { get; set; }

    public int AuthorID { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    public string Category { get; set; }

    public bool? IsPublished { get; set; }

    public int? ViewCount { get; set; }

    public bool? IsFeatured { get; set; }

    [StringLength(200)]
    public string Tags { get; set; }

    [ForeignKey("AuthorID")]
    [InverseProperty("Blogs")]
    public virtual User Author { get; set; }
}
