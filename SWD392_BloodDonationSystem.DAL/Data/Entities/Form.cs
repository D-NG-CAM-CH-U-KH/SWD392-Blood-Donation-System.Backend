using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("Form")]
public partial class Form
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FormID { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(100)]
    public string FormType { get; set; }

    public int MinQuestion { get; set; }

    public int MaxQuestion { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Form")]
    public virtual ICollection<FormQuestion> FormQuestions { get; set; } = new List<FormQuestion>();

    [InverseProperty("Form")]
    public virtual ICollection<UserForm> UserForms { get; set; } = new List<UserForm>();
}
