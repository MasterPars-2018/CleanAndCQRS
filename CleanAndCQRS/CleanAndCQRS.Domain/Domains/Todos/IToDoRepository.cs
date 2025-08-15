namespace CleanAndCQRS.Domain.Domains.Todos;

public interface IToDoRepository
{
    Task AddAsync(ToDoList toDoList);
    Task Delete(Guid toDoListId);
    Task UpdateAsync(Guid toDoListId, string title);
    void UpdateTasksAsync(ToDoList toDoList);
    Task<ToDoList> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    IQueryable<ToDoList>  GetToDoLists(CancellationToken cancellationToken = default);

}
