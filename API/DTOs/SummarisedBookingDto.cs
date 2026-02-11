using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using ConferenceBookingDomain;

public class SummarisedBookingDto
{
    public int id {get; set;}

    public string  location {get;set;}


    public string room {get;set;}
   
    public DateTime startTime {get;set;}
  
    public DateTime endTime {get;set;}
    public int capacity{get;set;}
}