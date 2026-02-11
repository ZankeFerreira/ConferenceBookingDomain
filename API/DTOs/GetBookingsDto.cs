public class GetBookingsDto
{
   
    public int room {get; set;}
   
    public DateTime startTime {get;set;}
  
    public DateTime endTime {get;set;}
    public int capacity{get;set;}
    public string UserId{get;set;}
    public string? VisitorName{get;set;}

}