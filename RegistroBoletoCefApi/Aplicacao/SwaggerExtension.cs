using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.PlatformAbstractions;

namespace RegistroBoletoCefApi.Application
{
    /// <summary>
    /// Calsse responsável pelo swagger
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Configura o swagger
        /// </summary>
        /// <param name="services">Services <seealso cref="IServiceCollection"/></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new OpenApiInfo
                             {
                                 Title = "Registro Boleto CEF",
                                 Version = "v1"
                             });

                // configura o xml
                var caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                var caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                // adiciona a autorização e os comentários pelo xml
                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }
    }
}