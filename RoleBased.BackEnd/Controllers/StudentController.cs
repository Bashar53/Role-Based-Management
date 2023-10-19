using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.RoleBased.Command;
using RoleBased.Core.CQRS.RoleBased.Query;
using RoleBased.Model;
using RoleBased.Service.Model;

namespace RoleBased.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : APIControllerBase
    {


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpGet("id:string")]

        public async Task<ActionResult<StudentInfo>> GetById(string id) 
        {
            return await HandleQueryAsync(new GetAllStudentByIdQuery(id));
        }

        [HttpGet]
        public async Task<ActionResult<StudentInfo>> GetAllStudent()  
        {
            return await HandleQueryAsync(new GetAllStudentQuery());
        }

        [HttpPost]
        public async Task<ActionResult<StudentInfo>> CreateStudent(VMStudent command) 
        {
            return await HandleCommandAsync(new CreateStudentCommand(command));
        }

    }
}
