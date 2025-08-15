using CleanAndCQRS.Application.ToDos.Dtos;
using MediatR;

namespace CleanAndCQRS.Application.ToDos.Queries;

public sealed class AllToDosQuery : IRequest<List<ToDoDto>>
{
}
