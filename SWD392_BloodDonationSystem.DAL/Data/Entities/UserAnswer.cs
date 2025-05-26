using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("UserAnswer")]
public partial class UserAnswer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnswerID { get; set; }

    public int UserFormID { get; set; }

    public int QuestionID { get; set; }

    public string Answer { get; set; }

    [ForeignKey("UserFormID")]
    [InverseProperty("UserAnswers")]
    public virtual UserForm UserForm { get; set; }
}
