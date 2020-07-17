using System.Threading.Tasks;
using Api.Models;
using FindAddresses.Services;
using Microsoft.AspNetCore.Mvc;
using PostcodeParser.UK;

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
        public async Task<IActionResult> GetAddress([FromQuery] Address address)
        {
            // Only valid postcodes
            if(Postcode.IsValid(address.Postcode))
            {
                var result = await this.service.GetPostCodeAsync(address.Postcode);
                return base.Ok(result);
            }
            // Else we consider a bad request and return the model
            // to inform the user of the bad request
            return base.BadRequest(address);
        }
    }
}
