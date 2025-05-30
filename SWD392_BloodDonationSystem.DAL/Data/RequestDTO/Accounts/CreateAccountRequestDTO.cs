using System.ComponentModel.DataAnnotations;

namespace SWD392_BloodDonationSystem.DAL.Data.RequestDTO.Accounts;

public class CreateAccountRequestDTO
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; }

    [StringLength(10, MinimumLength = 9, ErrorMessage = "Citizen ID must be 9–10 characters.")]
    public string CitizenID { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(20)]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public bool Gender { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    public DateOnly DateOfBirth { get; set; }

    public int? BloodGroupID { get; set; }

    [StringLength(100)]
    public string City { get; set; }

    [StringLength(100)]
    public string District { get; set; }

    [StringLength(100)]
    public string Ward { get; set; }

    [StringLength(100)]
    public string HouseNumber { get; set; }

    public int? Longitude { get; set; }

    public int? Latitude { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? CreatedAt { get; set; }
}
