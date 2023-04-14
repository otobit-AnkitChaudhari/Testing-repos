using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(new Core.Users().GetUser(id));
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Index([FromBody]MODEL.User value)
        {
            return Ok(new Core.Users().CreateUser(value));
        }


        [Route("edit/{id}")]
        [HttpPut]
        public IActionResult Index([FromRoute] int id, [FromBody] MODEL.User value)
        {
            return Ok(new Core.Users().EditUser(id, value));
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Index([FromRoute] int id)
        {
            return Ok(new Core.Users().DeleteUser(id));
        }
    }
}
