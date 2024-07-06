using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;

namespace TechChallenge_1.Domain.Features.AdicionarContato.Contexto
{
    public class ContextoAdicionarContato : IContextoAdicionarContato<RequisicaoAdicionarContato>
    {
        public RequisicaoAdicionarContato Requisicao { get; set; }
    }
}