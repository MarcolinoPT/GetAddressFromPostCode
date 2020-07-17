using FindAddresses.Services;
using RestEase;
using WebService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IPostCodeService, PostCodeService>()
                .AddSingleton<IWebServiceApi>(provider => RestClient.For<IWebServiceApi>("https://gmx7qarj73.execute-api.eu-west-1.amazonaws.com/v1"));
        }
    }
}
