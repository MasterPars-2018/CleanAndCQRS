namespace CleanAndCQRS.Application.ToDos.Dtos;

public class ToDoWithTaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public List<TaskDto> Tasks { get; set; }
}
