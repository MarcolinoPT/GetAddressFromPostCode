using System.Linq;
using System.Threading.Tasks;
using Api.Extensions;
using FindAddresses.DTOs;
using WebService;

namespace FindAddresses.Services
{
    public interface IPostCodeService
    {
        Task<PostCodeDto> GetPostCodeAsync(string postcode);
    }

    public class PostCodeService : IPostCodeService
    {
        private readonly IWebServiceClient webService;

        public PostCodeService(IWebServiceClient webService)
        {
            this.webService = webService ?? throw new System.ArgumentNullException(nameof(webService));
        }

        public async Task<PostCodeDto> GetPostCodeAsync(string postcode)
        {
            var result = await this.webService.FetchPostCodeAsync(postcode);
            return new PostCodeDto
            {
                Addresses = result.Addresses.Select(address => new Adress
                {
                    County = address.County,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Line3 = address.Line3,
                    Line4 = address.Line4,
                    Locality = address.Locality,
                    TownOrCity = address.TownOrCity
                }).ToList(),
                DistanceInKm = result.DistanceToHeathrowAirportInKm(),
                DistanceInMiles = result.DistanceToHeathrowAirportInMiles()
            };
        }
    }
}
