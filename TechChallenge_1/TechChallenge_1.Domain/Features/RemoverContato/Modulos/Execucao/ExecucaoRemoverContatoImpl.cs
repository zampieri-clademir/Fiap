using TechChallenge_1.Domain.Features.RemoverContato.Contexto;
using TechChallenge_1.Domain.Features.RemoverContato.Modulos.PersistirDados;
using TechChallenge_1.Domain.Features.RemoverContato.Requisicao;
using TechChallenge_1.Domain.Features.RemoverContato.Resposta;

namespace TechChallenge_1.Domain.Features.RemoverContato.Modulos.Execucao
{
    /// <summary>
    /// Classe principal onde faz o gerenciamento de todos os passos da execução da feature
    /// </summary>
    public class ExecucaoRemoverContatoImpl : IExecucaoRemoverContato
    {
        private readonly IPersistirDadosRemoverContato _persistirDados;

        public ExecucaoRemoverContatoImpl(IPersistirDadosRemoverContato persistirDados)
        {
            _persistirDados = persistirDados;
        }

        public RespostaRemoverContato Processar(RequisicaoRemoverContato requisicao)
        {
            ContextoRemoverContato contexto = new()
            {
                Requisicao = requisicao
            };

            var result = _persistirDados.Processar(contexto);

            return new RespostaRemoverContato() { Contexto = contexto, Successo= result };
        }
    }
}