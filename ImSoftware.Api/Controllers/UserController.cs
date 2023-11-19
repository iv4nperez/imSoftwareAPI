using ImSoftware.Api.DTOs;
using ImSoftware.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
                _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _userServices.GetAllUsers();
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserParamDTO userParam)
        {
            var user = await _userServices.PostCreateUser(userParam);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
           var user = await _userServices.DeleteUser(id);
           return Ok(user);
        }
    }
}
