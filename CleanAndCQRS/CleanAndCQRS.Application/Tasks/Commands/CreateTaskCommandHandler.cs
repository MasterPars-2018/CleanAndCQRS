using CleanAndCQRS.Domain;
using CleanAndCQRS.Domain.Domains.Todos;
using MediatR;

namespace CleanAndCQRS.Application.Tasks.Commands;

public class CreateTaskCommandHandler(IUnitOfWork unit)
    : IRequestHandler<CreateTaskCommand, Guid>
{
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {

        var toDoList = await unit.ToDoRepository.GetByIdAsync(request.ToDoId);

         var task = ToDoTask.CreateInstance(request.Title, request.Description);

        toDoList.AddTask(task);

        unit.ToDoRepository.UpdateTasksAsync(toDoList);

        await unit.CommitAsync();

        return task.Id;

    }
}
 
