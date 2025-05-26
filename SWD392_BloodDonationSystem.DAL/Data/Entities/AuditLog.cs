using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("AuditLog")]
public partial class AuditLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LogID { get; set; }

    public int UserID { get; set; }

    [StringLength(100)]
    public string Action { get; set; }

    [StringLength(100)]
    public string TargetTable { get; set; }

    public int? TargetID { get; set; }

    [Column(TypeName = "timestamp with time zone")]
    public DateTime Timestamp { get; set; }

    public string Description { get; set; }

    [StringLength(50)]
    public string IPAddress { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("AuditLogs")]
    public virtual User User { get; set; }
}
