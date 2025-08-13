namespace CleanAndCQRS.Domain.Exceptions;

public class TodoListNotFoundException : Exception
{
    public TodoListNotFoundException(string message) : base(message)
    {

    }
}