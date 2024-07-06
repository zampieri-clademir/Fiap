using AutoMapper;

using TechChallenge_1.Application.Dto.Contato;
using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;
using TechChallenge_1.Domain.Features.AdicionarContato.Resposta;

namespace TechChallenge_1.Application.Features.Contato.AdicionarContato
{
    public class AdicionarContatoApplicationMapper : Profile
    {
        public AdicionarContatoApplicationMapper()
        {
            CreateMap<AdicionarContatoCommand, RequisicaoAdicionarContato>();
            CreateMap<RespostaAdicionarContato, ContatoDto>();
        }
    }
}