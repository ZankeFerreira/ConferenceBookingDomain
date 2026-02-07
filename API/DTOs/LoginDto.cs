using ConferenceBookingDomain;
using System.ComponentModel.DataAnnotations;
public class LoginDto
{
    
    [Required(ErrorMessage = "Input Username")]
    public string Username{get; set;}
    [Required(ErrorMessage = "Input password")]
    [MinLength(8, ErrorMessage = "Password must be atleast 8 characters long")]
    public string Password{get; set;}
}