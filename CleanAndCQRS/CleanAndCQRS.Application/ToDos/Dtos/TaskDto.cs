namespace CleanAndCQRS.Application.ToDos.Dtos;

public class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string TaskState { get; set; }
     
}