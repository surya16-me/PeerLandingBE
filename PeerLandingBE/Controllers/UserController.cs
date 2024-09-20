using DAL.DTO.Req;
using DAL.DTO.Res;
using DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace PeerLandingBE.Controllers
{
    [Route("rest/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        public async Task<IActionResult> Register(ReqRegisterUserDto reqRegisterUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Any())
                        .Select(x => new
                        {
                            Field = x.Key,
                            Messages = x.Value.Errors.Select(e => e.ErrorMessage).ToList()
                        })
                        .ToList();

                    var errorMessage = new StringBuilder("Validation errors occurred");                    

                    return BadRequest(new ResBaseDto<object>
                    {
                        Success = false,
                        Message = errorMessage.ToString(),
                        Data = errors
                    });
                }

                // Register user logic
                var res = await _userServices.Register(reqRegisterUserDto);

                return Ok(new ResBaseDto<string>
                {
                    Success = true,
                    Message = "User registered successfully",
                    Data = res
                });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new ResBaseDto<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred. Please try again later.",
                    Data = null
                });
            }
        }

    }
}
