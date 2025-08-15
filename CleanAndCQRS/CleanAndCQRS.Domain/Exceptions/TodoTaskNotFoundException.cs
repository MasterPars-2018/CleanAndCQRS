namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskNotFoundException : DomainException
{
    public TodoTaskNotFoundException(string message) : base(message)
    {

    }
}
