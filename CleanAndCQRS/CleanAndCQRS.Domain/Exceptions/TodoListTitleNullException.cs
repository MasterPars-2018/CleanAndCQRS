namespace CleanAndCQRS.Domain.Exceptions;

public class TodoListTitleNullException : DomainException
{
    public TodoListTitleNullException(string message) : base(message)
    {
        
    }
}

