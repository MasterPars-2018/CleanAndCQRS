using CleanAndCQRS.Application.ToDos.Dtos;
using CleanAndCQRS.Domain;
using MediatR;

namespace CleanAndCQRS.Application.ToDos.Queries;

public class SingleToDoQueryHandler(IUnitOfWork unit)
    : IRequestHandler<SingleToDoQuery, ToDoWithTaskDto>
{
    public async Task<ToDoWithTaskDto> Handle(SingleToDoQuery request, CancellationToken cancellationToken)
    {
        var toDoList = await unit.ToDoRepository.GetByIdAsync(request.Id,cancellationToken);

        var dto = new ToDoWithTaskDto
        {
            Id = toDoList.Id,
            Title = toDoList.Title,
            Tasks = toDoList.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                TaskState = Enum.GetName(t.TaskState)!

            }).ToList(),
        };
                                
         return dto;

    }
}
