using CleanAndCQRS.Domain.Domains.Todos;

namespace CleanAndCQRS.Domain;

public interface IUnitOfWork:IDisposable
{
    public IToDoRepository ToDoRepository { get;}

    Task<int> CommitAsync();
}
