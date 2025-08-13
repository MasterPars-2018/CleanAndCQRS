namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskTitleNullException : Exception
{
    public TodoTaskTitleNullException(string message) : base(message)
    {

    }
}
