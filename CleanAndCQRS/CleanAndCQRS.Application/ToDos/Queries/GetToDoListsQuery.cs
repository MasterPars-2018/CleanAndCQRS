using CleanAndCQRS.Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CleanAndCQRS.Application.ToDos.Queries;

public sealed class GetToDoListsQuery : IRequest<List<ToDoListDto>>
{
}

public sealed class GetToDoListsQueryHandler(IUnitOfWork unit)
    : IRequestHandler<GetToDoListsQuery, List<ToDoListDto>>
{
    public async Task<List<ToDoListDto>> Handle(GetToDoListsQuery request, CancellationToken cancellationToken)
    {
        var data = await unit.ToDoRepository.GetToDoLists(cancellationToken)
            .Select(x => new ToDoListDto(x.Id, x.Title)).ToListAsync();

        return data;
    }
}
