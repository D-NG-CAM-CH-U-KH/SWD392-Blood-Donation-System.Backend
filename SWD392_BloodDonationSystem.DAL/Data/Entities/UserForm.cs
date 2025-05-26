using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("UserForm")]
public partial class UserForm
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserFormID { get; set; }

    public int UserID { get; set; }

    public int FormID { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("FormID")]
    [InverseProperty("UserForms")]
    public virtual Form Form { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("UserForms")]
    public virtual User User { get; set; }

    [InverseProperty("UserForm")]
    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
