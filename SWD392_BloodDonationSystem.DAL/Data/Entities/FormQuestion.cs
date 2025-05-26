using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("FormQuestion")]
public partial class FormQuestion
{
    [Key]
    public int QuestionID { get; set; }

    public int FormID { get; set; }

    [Required]
    public string QuestionText { get; set; }

    [Required]
    [StringLength(100)]
    public string QuestionType { get; set; }

    public bool IsActive { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("FormID")]
    [InverseProperty("FormQuestions")]
    public virtual Form Form { get; set; }
}
