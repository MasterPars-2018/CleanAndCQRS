namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskTitleDuplicateException : DomainException
{
    public TodoTaskTitleDuplicateException(string message) : base(message)
    {

    }
}
