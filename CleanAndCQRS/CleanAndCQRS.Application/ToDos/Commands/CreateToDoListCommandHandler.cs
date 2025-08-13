using CleanAndCQRS.Domain;
using CleanAndCQRS.Domain.Domains.Todos;
using MediatR;

namespace CleanAndCQRS.Application.ToDos.Commands;

public sealed class CreateToDoListCommandHandler(IUnitOfWork unit)
    : IRequestHandler<CreateToDoListCommand, Guid>
{
     
    public async Task<Guid> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
    { 
        var toDoList = ToDoList.CreateInstance(request.Title); 
        await  unit.ToDoRepository.AddAsync(toDoList);
        await unit.CommitAsync();
        return toDoList.Id;
    }
}