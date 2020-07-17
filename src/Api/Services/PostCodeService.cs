using System.Threading.Tasks;
using FindAddresses.DTOs;
using WebService;

namespace FindAddresses.Services
{
    public interface IPostCodeService
    {
        Task<PostCodeDto> GetPostCode(string postcode);
    }

    public class PostCodeService : IPostCodeService
    {
        private readonly IWebServiceApi webService;

        public PostCodeService(IWebServiceApi webService)
        {
            this.webService = webService ?? throw new System.ArgumentNullException(nameof(webService));
        }

        public async Task<PostCodeDto> GetPostCode(string postcode)
        {
            var result = await this.webService.FetchPostCodeAsync(postcode);
            return new PostCodeDto
            {
                Addresses = (System.Collections.Generic.ICollection<Adress>)result.Addresses,
                Latitude = result.Latitude,
                Longitude = result.Longitude
            };
        }
    }
}
