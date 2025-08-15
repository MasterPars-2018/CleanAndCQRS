namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskStateCannotChangeException : DomainException
{
    public TodoTaskStateCannotChangeException(string message) : base(message)
    {

    }
}

