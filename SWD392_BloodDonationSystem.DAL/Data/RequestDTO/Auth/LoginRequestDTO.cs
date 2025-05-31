using System.ComponentModel.DataAnnotations;

namespace SWD392_BloodDonationSystem.DAL.Data.RequestDto.Auth;

public class LoginRequestDTO
{
    [Required(ErrorMessage = "CitizenID is required")]
    public string CitizenID { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}