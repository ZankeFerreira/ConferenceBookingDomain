public class InvalidUserException : Exception
{
    public InvalidUserException() : base("Your credentials are invalid") { }
}
