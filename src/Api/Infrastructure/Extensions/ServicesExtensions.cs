using FindAddresses.Services;
using WebService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPostCodeService, PostCodeService>();
            services.AddHttpClient<IWebServiceClient, WebServiceClient>();
            return services;
        }
    }
}
