using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("DonationForm")]
public partial class DonationForm
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DonationFormID { get; set; }
    
    public bool IsDonated { get; set; }
    
    [StringLength(255)]
    public string Illness { get; set; }
    
    [StringLength(255)]
    public string DangerousIllness { get; set; }
    
    [StringLength(255)]
    public string TwelveMonthProblem { get; set; }
    
    [StringLength(255)]
    public string SixMonthProblem { get; set; }
    
    [StringLength(255)]
    public string OneMonthProblem { get; set; }
    
    [StringLength(255)]
    public string FourteenDayProblem { get; set; }
    
    [StringLength(255)]
    public string SevenDayProblem { get; set; }
    
    [StringLength(255)]
    public string WomanProblem { get; set; }
    
    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("DonationForm")]
    public virtual DonationAppointment Appointment { get; set; }
}
