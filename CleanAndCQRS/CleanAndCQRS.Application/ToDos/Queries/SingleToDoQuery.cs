using CleanAndCQRS.Application.ToDos.Dtos;
using MediatR;

namespace CleanAndCQRS.Application.ToDos.Queries;

public class SingleToDoQuery : IRequest<ToDoWithTaskDto>
{
    public required Guid Id { get; set; }
}
