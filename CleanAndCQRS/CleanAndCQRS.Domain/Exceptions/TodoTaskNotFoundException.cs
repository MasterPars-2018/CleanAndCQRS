namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskNotFoundException : Exception
{
    public TodoTaskNotFoundException(string message) : base(message)
    {

    }
}
