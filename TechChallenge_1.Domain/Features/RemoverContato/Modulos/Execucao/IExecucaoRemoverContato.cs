using TechChallenge_1.Domain.Features.RemoverContato.Requisicao;
using TechChallenge_1.Domain.Features.RemoverContato.Resposta;

namespace TechChallenge_1.Domain.Features.RemoverContato.Modulos.Execucao
{
    public interface IExecucaoRemoverContato
    {
        new RespostaRemoverContato Processar(RequisicaoRemoverContato requisicao);
    }
}
