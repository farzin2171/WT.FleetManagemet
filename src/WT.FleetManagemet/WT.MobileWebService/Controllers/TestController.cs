using Microsoft.AspNetCore.Mvc;

namespace WT.MobileWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { name = "test" });
        }
    }
}
