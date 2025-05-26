using Microsoft.EntityFrameworkCore;
using SWD392_BloodDonationSystem.DAL.Data.Entities;

namespace SWD392_BloodDonationSystem.DAL.Context;

public class SeedingData
{
    #region Static data sources
    
    private static readonly List<User> Users = [
        new User { FullName = "Admin Account", Email = "admin.account@example.com", CitizenID = "123456789", Phone = "0123456789", Gender = true, DateOfBirth = new DateOnly(1990, 5, 15), BloodGroupID = 1, City = "New York", District = "Manhattan", Ward = "Central", HouseNumber = "123", Longitude = 40, Latitude = -74, IsActive = true, CreatedAt = DateTime.UtcNow },
        new User { FullName = "Staff Account", Email = "staff.account@example.com", CitizenID = "987654321", Phone = "0987654321", Gender = false, DateOfBirth = new DateOnly(1985, 10, 20), BloodGroupID = 2, City = "Los Angeles", District = "Hollywood", Ward = "West", HouseNumber = "456", Longitude = 34, Latitude = -118, IsActive = true, CreatedAt = DateTime.UtcNow },
        new User { FullName = "Member Account", Email = "member.account@example.com", CitizenID = "555666777", Phone = "0111222333", Gender = false, DateOfBirth = new DateOnly(1995, 8, 30), BloodGroupID = 3, City = "Chicago", District = "Lincoln Park", Ward = "North", HouseNumber = "789", Longitude = 41, Latitude = -87, IsActive = true, CreatedAt = DateTime.UtcNow }
    ];

    private static readonly List<UserRole> UserRoles = [];
    
    private static readonly List<Role> Roles = [
        new Role { RoleName = Role.Admin, Description = "Administrator with full access", CreatedAt = DateTime.UtcNow },
        new Role { RoleName = Role.Staff, Description = "Staff member with limited access", CreatedAt = DateTime.UtcNow },
        new Role { RoleName = Role.Member, Description = "Regular member who use this app", CreatedAt = DateTime.UtcNow }
    ];
    
    private static readonly List<BloodGroup> BloodGroups = [
        new BloodGroup { BloodType = "A+", Description = "A Positive", CanDonateTo = "A+, AB+", CanReceiveFrom = "A+, A-, O+, O-" },
        new BloodGroup { BloodType = "A-", Description = "A Negative", CanDonateTo = "A+, A-, AB+, AB-", CanReceiveFrom = "A-, O-" },
        new BloodGroup { BloodType = "B+", Description = "B Positive", CanDonateTo = "B+, AB+", CanReceiveFrom = "B+, B-, O+, O-" },
        new BloodGroup { BloodType = "B-", Description = "B Negative", CanDonateTo = "B+, B-, AB+, AB-", CanReceiveFrom = "B-, O-" },
        new BloodGroup { BloodType = "AB+", Description = "AB Positive", CanDonateTo = "AB+", CanReceiveFrom = "All" },
        new BloodGroup { BloodType = "AB-", Description = "AB Negative", CanDonateTo = "AB+, AB-", CanReceiveFrom = "A-, B-, AB-, O-" },
        new BloodGroup { BloodType = "O+", Description = "O Positive", CanDonateTo = "A+, B+, AB+, O+", CanReceiveFrom = "O+, O-" },
        new BloodGroup { BloodType = "O-", Description = "O Negative", CanDonateTo = "All", CanReceiveFrom = "O-" }
    ];
    
    #endregion 
    
    // Find and seed

    private static void SetUserRole()
    {
        if(UserRoles.Count > 0) return;
        foreach (var user in Users)
        {
            var role = Roles.FirstOrDefault(r => user.FullName.Contains(r.RoleName));
            UserRoles.Add(new UserRole
            {
                User = user,
                Role = role,
                AssignedAt = DateTime.UtcNow
            });
        }
    }

    private static async Task FindAndSetAsync<TEntity>(DbContext context, List<TEntity> records) where TEntity: class
    {
        var existing = await context.Set<TEntity>().AnyAsync();
        if (!existing) await context.Set<TEntity>().AddRangeAsync(records);
    }
    
    private static void FindAndSet<TEntity>(DbContext context, List<TEntity> records) where TEntity: class
    {
        var existing = context.Set<TEntity>().Any();
        if (!existing) context.Set<TEntity>().AddRange(records);
    }
    
    // Seed Data
    public static async Task SeedAsync(DbContext context, CancellationToken cancellationToken)
    {
        await FindAndSetAsync(context, BloodGroups);
        await FindAndSetAsync(context, Roles);
        await FindAndSetAsync(context, Users);
        
        // User Roles
        SetUserRole();
        await FindAndSetAsync(context, UserRoles);

        await FindAndSetAsync(context, UserRoles);
        await context.SaveChangesAsync(cancellationToken);
    }

    public static void Seed(DbContext context)
    {
        FindAndSet(context,BloodGroups);
        FindAndSet(context, Roles);
        FindAndSet(context, Users);
        
        // User Roles
        SetUserRole();
        FindAndSet(context, UserRoles);
        
        context.SaveChanges();
    }
}
