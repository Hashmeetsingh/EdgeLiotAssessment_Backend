using EdgeLiotAssessment.Interfaces;
using EdgeLiotAssessment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdgeLiotAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EdgeLiotController : ControllerBase
    {
        private readonly ILogger<EdgeLiotController> _logger;
        private readonly IUserDetailsService _iUserDetailsService;
        public EdgeLiotController(ILogger<EdgeLiotController> logger, IUserDetailsService userDetailsService)
        {
            _logger = logger;
            _iUserDetailsService = userDetailsService;
        }

        [HttpPost]
        [Route("saveUserDetails")]
        public IActionResult SaveUserDetails(UserDetails userDetails)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response = _iUserDetailsService.SaveAndUpdateUserDetails(userDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error:{ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("getUserDetails")]
        public IActionResult GetUserDetails()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response = _iUserDetailsService.GetUserdetails();
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error:{ex.Message}";
                return BadRequest(response);
            }
        }
    }
}