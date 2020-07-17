using Microsoft.AspNetCore.Mvc;

namespace FindAddresses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        [HttpGet()]
        public IActionResult GetAddress([FromQuery] string postcode)
        {
            // TODO Validate post code format
            // TODO Return results
            return base.Ok();
        }
    }
}
