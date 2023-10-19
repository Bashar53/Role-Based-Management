using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.RoleBased.Command;
using RoleBased.Core.CQRS.RoleBased.Query;
using RoleBased.Model;
using RoleBased.Service.Model;

namespace RoleBased.BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginDBController : APIControllerBase
{


    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [HttpGet("id:string")]


    public async Task<ActionResult<LoginDB>> GetById(string id)
    {
        return await HandleQueryAsync(new GetAllLoginDBByIdQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult<LoginDB>> GetAllLoginDB()    
    {
        return await HandleQueryAsync(new GetAllLoginDBQuery());
    }

    [HttpPost]
    public async Task<ActionResult<LoginDB>> CreateLoginDB(VMLoginDB command)
    {
        return await HandleCommandAsync(new CreateLoginDBCommand(command));
    }






}
