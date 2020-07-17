using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAddress([FromQuery] string postcode)
        {
            // TODO Validate post code format
            var result = await this.service.GetPostCodeAsync(postcode);
            return base.Ok(result);
        }
    }
}
