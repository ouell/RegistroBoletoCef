using AutoMapper;
using RegistroBoletoCefApi.Models;

namespace RegistroBoletoCefApi
{
    /// <summary>
    /// Classe responsável pelo automapper
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Método responsável pela configuração do automapper
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<SolicitacaoDto, SolicitacaoRetornoDto>()
               .ForMember(d => d.PagadorPessoaFisica, e => e.MapFrom((s, d) => s.PessoaPagador.PessoaFisica))
               .ForMember(d => d.PagadorPessoaJuridica, e => e.MapFrom((s, d) => s.PessoaPagador.PessoaJuridica));
        }
    }
}