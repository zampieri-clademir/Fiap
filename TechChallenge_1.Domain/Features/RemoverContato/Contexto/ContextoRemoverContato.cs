using TechChallenge_1.Domain.Features.RemoverContato.Requisicao;
using TechChallenge_1.Domain.Features.RemoverContato.Resposta;

namespace TechChallenge_1.Domain.Features.RemoverContato.Contexto
{
    public class ContextoRemoverContato : IContextoRemoverContato<RequisicaoRemoverContato>
    {
        public RequisicaoRemoverContato Requisicao { get; set; }
    }
}