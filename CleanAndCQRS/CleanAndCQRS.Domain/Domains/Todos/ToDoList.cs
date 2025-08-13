using CleanAndCQRS.Domain.Commons;
using CleanAndCQRS.Domain.Exceptions;

namespace CleanAndCQRS.Domain.Domains.Todos;

public class ToDoList : BaseEntity
{

    private readonly List<ToDoTask> _tasks = new();
    private ToDoList(Guid id, string title) : base(id)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new TodoListTitleNullException("Todo list's title cann't be null or empty");
        Title = title;
    }
    public string Title { get; private set; }
    public IReadOnlyCollection<ToDoTask> Tasks => _tasks.AsReadOnly();
     
    public static ToDoList CreateInstance(string title)
    {
        return new ToDoList(Guid.CreateVersion7(), title);
    }
      
    public void UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new TodoListTitleNullException("Todo list's title cann't be null or empty");

        Title = title;
    }
     
    public void AddTask(ToDoTask task)
    {

        if (_tasks.Exists(x => x.Title.ToLower().Equals(task.Title.ToLower())))
        {
            throw new TodoTaskTitleDuplicateException("Task title is duplicate");
        }
        _tasks.Add(task);

    }


    public void DeleteTask(Guid taskId)
    {
        var task = _tasks.FirstOrDefault(x => x.Id == taskId);

        _tasks.Remove(task);

    }

    private ToDoTask GetTaskById(Guid taskId)
    {
        var task = _tasks.FirstOrDefault(x => x.Id == taskId);
        if (task == null)
        {

            throw new TodoTaskNotFoundException("Task not found");
        }

        return task;
    }
     

}
