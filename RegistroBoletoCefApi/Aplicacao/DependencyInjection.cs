using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistroBoletoCefApi.ClientApi;
using RegistroBoletoCefApi.ClientApi.IClientApi;

namespace RegistroBoletoCefApi
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Injeta as dependências necessarias
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InjectMyDependencies(this IServiceCollection services,
                                                IConfiguration configuration)
        {
            services.AddScoped<IClientApiCef, ClientApiCef>();
        }
    }
}