namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskTitleDuplicateException : Exception
{
    public TodoTaskTitleDuplicateException(string message) : base(message)
    {

    }
}
