using FindAddresses.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindAddresses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly IPostCodeService service;

        public AddressController(IPostCodeService service)
        {
            this.service = service ?? throw new System.ArgumentNullException(nameof(service));
        }

        [HttpGet()]
        public IActionResult GetAddress([FromQuery] string postcode)
        {
            // TODO Validate post code format
            return base.Ok(this.service.GetPostCode(postcode));
        }
    }
}
