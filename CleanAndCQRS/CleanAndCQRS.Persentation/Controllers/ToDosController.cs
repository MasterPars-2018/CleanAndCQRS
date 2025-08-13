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
        var data = await mediatR.Send(new GetToDoListsQuery());
        return Ok(data);
    }


    [HttpPost(Name = "Create")]
    public async Task<IActionResult> Create([FromBody] CreateToDoListCommand command)
    {
        var id = await mediatR.Send(command);
        return   Ok(id) ;
    }
     
}