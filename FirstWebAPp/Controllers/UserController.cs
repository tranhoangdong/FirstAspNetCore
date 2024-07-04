using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstWebAPp.Controllers
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
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            var resultToken = await _userServices.Authecate(loginRequest);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("User or password is incorrect");
            }
            return Ok(new { token = resultToken });

        }
        [HttpPost("reister")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            var result = await _userServices.Register(registerRequest);
            if (!result)
            {
                return BadRequest("register is unsuccesful ");
            }
            return Ok();
        }
    }
}
