namespace CleanAndCQRS.Domain.Exceptions;

public class TodoListTitleNullException : Exception
{
    public TodoListTitleNullException(string message) : base(message)
    {
        
    }
}

