using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [Route("Get/{id}")]
        [HttpGet]

        public IActionResult Get([FromRoute] int id)
        {
            return Ok(new Core.Logins().GetLogins(id));
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Index([FromBody] MODEL.Login value)
        {
            return Ok(new Core.Logins().CreateLogins(value));
        }

        [Route("edit/{id}")]
        [HttpPut]

        public IActionResult Index([FromRoute] int id, [FromBody] MODEL.Login value)
        {
            return Ok (new Core.Logins().EditLogin(id, value));
        }

        [Route("delete/{id}")]
        [HttpDelete]    

        public  IActionResult Delete([FromRoute] int id)
        {
            return Ok (new Core.Logins().DeleteLogin(id));
        }
     
  
    }
}
