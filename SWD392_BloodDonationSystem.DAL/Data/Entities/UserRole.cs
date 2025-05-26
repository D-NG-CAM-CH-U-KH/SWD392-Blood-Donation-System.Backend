using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("UserRole")]
public partial class UserRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserRoleID { get; set; }

    public int UserID { get; set; }

    public int RoleID { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime AssignedAt { get; set; }

    [ForeignKey("RoleID")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("UserRoles")]
    public virtual User User { get; set; }
}
