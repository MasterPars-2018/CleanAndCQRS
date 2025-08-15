using MediatR;
using System.Threading.Tasks;

namespace CleanAndCQRS.Application.Tasks.Commands;

public class CreateTaskCommand : IRequest<Guid>
{
    public Guid ToDoId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}
 
