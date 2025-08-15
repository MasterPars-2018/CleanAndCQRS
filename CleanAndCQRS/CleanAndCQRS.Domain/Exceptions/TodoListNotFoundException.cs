namespace CleanAndCQRS.Domain.Exceptions;

public class TodoListNotFoundException : DomainException
{
    public TodoListNotFoundException(string message) : base(message)
    {

    }
}