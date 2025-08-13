using CleanAndCQRS.Domain.Commons;
using CleanAndCQRS.Domain.Exceptions;

namespace CleanAndCQRS.Domain.Domains.Todos;

public class ToDoTask : BaseEntity
{
    public ToDoTask(Guid id, 
        string title,
        string? description, 
        TaskState taskState,
        DateTime createdAtUtc) : base(id)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new TodoListTitleNullException("Task's title cann't be null or empty");

        Title = title;
        Description = description;
        CreatedAtUtc = createdAtUtc;
        TaskState = taskState;
    }

    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime? ChangeStatedAtUtc { get; private set; } =null;
    public DateTime? TaskFinishedAtUtc { get; private set; } = null;
     
    public TaskState TaskState { get; private set; }


    internal void ChangeState(TaskState newState)
    {
        if(TaskState == TaskState.ToDo && newState == TaskState.Done)
        {
            throw new TodoTaskStateCannotChangeException("You cann't change state from 'ToDo' to 'Done' ");
        }

        if(TaskState == TaskState.ToDo && newState!= TaskState.ToDo)
        {
            throw new TodoTaskStateCannotChangeException("You cann't change finished task's state ");
        }

        if (newState ==TaskState.Done)
        {
            TaskFinishedAtUtc = DateTime.UtcNow;
        }

        TaskState = newState;
        ChangeStatedAtUtc = DateTime.UtcNow;

    }
     
    internal static ToDoTask CreateInstance(string title, string? description)
    {
        return new ToDoTask(Guid.CreateVersion7(), title,
            description,
            TaskState.ToDo, 
            DateTime.UtcNow);
    }


}
