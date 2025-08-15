namespace CleanAndCQRS.Domain.Exceptions;

public class TodoTaskTitleNullException : DomainException
{
    public TodoTaskTitleNullException(string message) : base(message)
    {

    }
}
