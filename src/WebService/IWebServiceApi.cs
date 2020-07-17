using System.Threading.Tasks;
using WebService.Requests;
using RestEase;

namespace WebService
{
    public interface IWebServiceApi
    {
        [Get("lookup")]
        Task<PostCodeDto> FetchPostCodeAsync([Query] string postcode);
    }
}
