using CleanAndCQRS.Application.Tasks.Commands;
using CleanAndCQRS.Application.ToDos.Commands;
using CleanAndCQRS.Application.ToDos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanAndCQRS.Persentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDosController : ControllerBase
{
    private readonly ISender mediatR;

    public ToDosController(ISender mediatR)
    {
        this.mediatR = mediatR;
    }

    [HttpGet]

    public async Task<IActionResult> Get()
    {
        var data = await mediatR.Send(new AllToDosQuery());
        return Ok(data);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var toDoList = await mediatR.Send(new SingleToDoQuery { Id = id });
        return Ok(toDoList);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateToDoListCommand command)
    {
        var id = await mediatR.Send(command);
        return   Ok(id) ;
    }


    [HttpPost]
    [Route("tasks")]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
    {
        var id = await mediatR.Send(command);
        return Ok(id);
    }

 


}