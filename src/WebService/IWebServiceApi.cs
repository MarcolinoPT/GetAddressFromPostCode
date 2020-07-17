using System.Threading.Tasks;
using WebService.Responses;
using RestEase;

namespace WebService
{
    public interface IWebServiceApi
    {
        [Get("lookup")]
        Task<PostCode> FetchPostCodeAsync([Query] string postcode);
    }
}
