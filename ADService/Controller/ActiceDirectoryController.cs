using Microsoft.AspNetCore.Mvc;
using UserManagement.Common.Dtos;
using UserManagement.Common.Responses;
using UserManagement.Common.Wrapper;

namespace ADService.Controller
{
    [Route("api/ad/[controller]")]
    [ApiController]
    public class ActiveDirectoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CheckingNameResponse>> CheckName(string Name)
        {
            var name = new CheckingNameResponse();
            name.Name = String.Empty; // name.Name = Name; - если уже существует
            return Ok(await Result<CheckingNameResponse>.SuccessAsync(name));
        }
    }
}
