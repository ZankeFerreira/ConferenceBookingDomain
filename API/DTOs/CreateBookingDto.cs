using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using ConferenceBookingDomain;

public class CreateBookingDto
{
    [Required]
    public int roomId {get; set;}
    [Required]
    public DateTime startTime {get;set;}
    [Required]
    public DateTime endTime {get;set;}
    public string? visitorName{get;set;}
    public int capacity{get;set;}
}