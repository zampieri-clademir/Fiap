using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;
using TechChallenge_1.Domain.Features.AdicionarContato.Resposta;

namespace TechChallenge_1.Domain.Features.AdicionarContato.Modulos.Execucao
{
    public interface IExecucaoAdicionarContato
    {
        RespostaAdicionarContato Processar(RequisicaoAdicionarContato requisicao);
    }
}
