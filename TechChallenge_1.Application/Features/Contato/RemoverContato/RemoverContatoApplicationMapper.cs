using AutoMapper;

using TechChallenge_1.Application.Dto.Contato;
using TechChallenge_1.Domain.Features.RemoverContato.Requisicao;
using TechChallenge_1.Domain.Features.RemoverContato.Resposta;

namespace TechChallenge_1.Application.Features.Contato.RemoverContato
{
    public class RemoverContatoApplicationMapper : Profile
    {
        public RemoverContatoApplicationMapper()
        {
            CreateMap<RemoverContatoCommand, RequisicaoRemoverContato>();
            CreateMap<RespostaRemoverContato, ContatoDto>();
        }
    }
}