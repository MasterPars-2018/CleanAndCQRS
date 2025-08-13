using CleanAndCQRS.Domain;
using CleanAndCQRS.Domain.Domains.Todos;
using CleanAndCQRS.Infrastructure.Domains.ToDo;
using CleanAndCQRS.Infrastructure.Persistence;

namespace CleanAndCQRS.Infrastructure;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbontext = dbContext;
    private readonly IToDoRepository _toDoRepository;

    public IToDoRepository ToDoRepository { get => _toDoRepository ?? new ToDoRepository(_dbontext); }

    public Task<int> CommitAsync()
    {
        return _dbontext.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbontext.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
