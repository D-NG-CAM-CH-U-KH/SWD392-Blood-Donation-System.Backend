using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SWD392_BloodDonationSystem.DAL.Data.Entities;

namespace SWD392_BloodDonationSystem.DAL.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }
    
    public virtual DbSet<AvailableDonateDate> AvailableDonateDates { get; set; }


    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BloodDonation> BloodDonations { get; set; }

    public virtual DbSet<BloodGroup> BloodGroups { get; set; }

    public virtual DbSet<BloodMatchingLog> BloodMatchingLogs { get; set; }

    public virtual DbSet<BloodRequest> BloodRequests { get; set; }

    public virtual DbSet<BloodTypeCertificate> BloodTypeCertificates { get; set; }

    public virtual DbSet<DonationAppointment> DonationAppointments { get; set; }

    public virtual DbSet<DonationSchedule> DonationSchedules { get; set; }

    public virtual DbSet<Image> Images { get; set; }
    
    public virtual DbSet<Reminder> Reminders { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SystemSetting> SystemSettings { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    public virtual DbSet<DonationForm> UserForms { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSeeding((context, _) => SeedingData.Seed(context))
            .UseAsyncSeeding(
                async (context, _, cancellationToken) => await SeedingData.SeedAsync(context, cancellationToken)
                );
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogID).HasName("AuditLogs_pkey");

            entity.Property(e => e.LogID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLogs_UserID");
        });
        
        modelBuilder.Entity<AvailableDonateDate>(entity =>
        {
            entity.HasKey(e => e.AvailableDateID).HasName("AvailableDonateDates_pkey");

            entity.Property(e => e.AvailableDateID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.User).WithMany(p => p.AvailableDonateDates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AvailableDonateDates_UserID");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogID).HasName("Blogs_pkey");

            entity.Property(e => e.BlogID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Author).WithMany(p => p.Blogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blogs_AuthorID");
        });

        modelBuilder.Entity<BloodDonation>(entity =>
        {
            entity.HasKey(e => e.DonationID).HasName("BloodDonations_pkey");

            entity.Property(e => e.DonationID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.BloodGroup).WithMany(p => p.BloodDonations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloodDonations_BloodGroupID");

            entity.HasOne(d => d.User).WithMany(p => p.BloodDonations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloodDonations_UserID");
        });

        modelBuilder.Entity<BloodGroup>(entity =>
        {
            entity.HasKey(e => e.BloodGroupID).HasName("BloodGroup_pkey");

            entity.Property(e => e.BloodGroupID).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<BloodMatchingLog>(entity =>
        {
            entity.HasKey(e => e.MatchID).HasName("BloodMatchingLogs_pkey");

            entity.Property(e => e.MatchID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Donor).WithMany(p => p.BloodMatchingLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloodMatchingLogs_DonorID");

            entity.HasOne(d => d.Request).WithOne(p => p.BloodMatchingLog)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloodMatchingLogs_RequestID");
            
            entity.HasOne(d => d.Appointment)
                .WithOne(p => p.BloodMatchingLog)
                .HasForeignKey<BloodMatchingLog>(d => d.AppointmentID)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_BloodMatchingLogs_AppointmentID");
        });

        modelBuilder.Entity<BloodRequest>(entity =>
        {
            entity.HasKey(e => e.RequestID).HasName("BloodRequests_pkey");

            entity.Property(e => e.RequestID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.BloodGroup).WithMany(p => p.BloodRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloodRequests_BloodGroupID");

            entity.HasOne(d => d.MatchedDonor).WithMany(p => p.BloodRequestMatchedDonors).HasConstraintName("FK_BloodRequests_MatchedDonorID");

            entity.HasOne(d => d.Requester).WithMany(p => p.BloodRequestRequesters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloodRequests_RequesterID");
        });

        modelBuilder.Entity<BloodTypeCertificate>(entity =>
        {
            entity.HasKey(e => e.CertificateID).HasName("BloodTypeCertificate_pkey");

            entity.Property(e => e.CertificateID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.User).WithMany(p => p.BloodTypeCertificates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloodTypeCertificate_UserID");
        });

        modelBuilder.Entity<DonationAppointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentID).HasName("DonationAppointments_pkey");

            entity.Property(e => e.AppointmentID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.DonationSchedule).WithMany(p => p.DonationAppointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonationAppointments_DonationScheduleID");

            entity.HasOne(d => d.User).WithMany(p => p.DonationAppointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonationAppointments_UserID");
            
            entity.HasOne(d => d.DonationForm).WithOne(p => p.Appointment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonationAppointments_DonationFormID");
        });
        
        modelBuilder.Entity<DonationForm>(entity =>
        {
            entity.HasKey(e => e.DonationFormID).HasName("DonationForms_pkey");
            
            entity.Property(e => e.DonationFormID).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<DonationSchedule>(entity =>
        {
            entity.HasKey(e => e.DonationTime).HasName("DonationSchedule_pkey");

            entity.Property(e => e.DonationTime).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DonationSchedules).HasConstraintName("FK_DonationSchedule_CreatedBy");
        });
        
        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageID).HasName("Image_pkey");

            entity.Property(e => e.ImageID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Images).HasConstraintName("FK_Image_UploadedBy");
        });

        modelBuilder.Entity<Reminder>(entity =>
        {
            entity.HasKey(e => e.ReminderID).HasName("Reminders_pkey");

            entity.Property(e => e.ReminderID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.User).WithMany(p => p.Reminders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reminders_UserID");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportID).HasName("Reports_pkey");

            entity.Property(e => e.ReportID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.GeneratedByNavigation).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reports_GeneratedBy");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleID).HasName("Roles_pkey");

            entity.Property(e => e.RoleID).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<SystemSetting>(entity =>
        {
            entity.HasKey(e => e.SettingID).HasName("SystemSettings_pkey");

            entity.Property(e => e.SettingID).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("Users_pkey");

            entity.Property(e => e.UserID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.BloodGroup).WithMany(p => p.Users).HasConstraintName("FK_Users_BloodGroupID");
        });
        
        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleID).HasName("UserRoles_pkey");

            entity.Property(e => e.UserRoleID).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_RoleID");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
