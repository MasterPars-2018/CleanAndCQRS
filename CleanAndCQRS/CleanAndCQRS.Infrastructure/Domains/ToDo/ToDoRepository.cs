using CleanAndCQRS.Domain.Domains.Todos;
using CleanAndCQRS.Domain.Exceptions;
using CleanAndCQRS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanAndCQRS.Infrastructure.Domains.ToDo;

internal class ToDoRepository : IToDoRepository
{
    private readonly ApplicationDbContext dbContext;
    private readonly DbSet<ToDoList> doLists;

    public ToDoRepository(ApplicationDbContext _dbContext)
    {
            dbContext = _dbContext;
            doLists = dbContext.ToDoLists;
    }

    public async Task AddAsync(ToDoList toDoList)
    {
        await doLists.AddAsync(toDoList);
    }

    public async Task Delete(Guid toDoListId)
    {
        var todoList = await doLists.FirstOrDefaultAsync(x => x.Id == toDoListId);
        if (todoList == null) throw  new TodoListNotFoundException("ToDo list not found");

        doLists.Remove(todoList);

    }

    public async Task<ToDoList> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var todoList = await doLists.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        if (todoList == null) throw new TodoListNotFoundException("ToDo list not found");

        return todoList;
    }

    public  IQueryable<ToDoList>  GetToDoLists(CancellationToken cancellationToken = default)
    {
        return doLists;
    }

    public async Task UpdateAsync(Guid toDoListId, string title) 
    {
        var todoList = await doLists.FirstOrDefaultAsync(x => x.Id == toDoListId);
        if (todoList == null) throw new TodoListNotFoundException("ToDo list not found");

        todoList.UpdateTitle(title);    
    }




}
