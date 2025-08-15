using CleanAndCQRS.Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanAndCQRS.Application.ToDos.Dtos;

namespace CleanAndCQRS.Application.ToDos.Queries;

public sealed class AllToDosQueryHandler(IUnitOfWork unit)
    : IRequestHandler<AllToDosQuery, List<ToDoDto>>
{
    public async Task<List<ToDoDto>> Handle(AllToDosQuery request, CancellationToken cancellationToken)
    {
        var data = await unit.ToDoRepository.GetToDoLists(cancellationToken)
            .Select(x => new ToDoDto(x.Id, x.Title)).ToListAsync();

        return data;
    }
}
