using MediatR;

namespace CleanAndCQRS.Application.ToDos.Commands;

public sealed class CreateToDoListCommand : IRequest<Guid>
{
    public required string Title { get; set; }
}
