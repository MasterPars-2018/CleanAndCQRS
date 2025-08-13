namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskStateCannotChangeException : Exception
{
    public TodoTaskStateCannotChangeException(string message) : base(message)
    {

    }
}

