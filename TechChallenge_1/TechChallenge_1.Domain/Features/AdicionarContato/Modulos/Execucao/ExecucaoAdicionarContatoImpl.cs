using TechChallenge_1.Domain.Features.AdicionarContato.Contexto;
using TechChallenge_1.Domain.Features.AdicionarContato.Modulos.PersistirDados;
using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;
using TechChallenge_1.Domain.Features.AdicionarContato.Resposta;

namespace TechChallenge_1.Domain.Features.AdicionarContato.Modulos.Execucao
{
    /// <summary>
    /// Classe principal onde faz o gerenciamento de todos os passos da execução da feature
    /// </summary>
    public class ExecucaoAdicionarContatoImpl : IExecucaoAdicionarContato 
    {
        private readonly IPersistirDadosAdicionarContato _persistirDados;

        public ExecucaoAdicionarContatoImpl(IPersistirDadosAdicionarContato persistirDados)
        {
            _persistirDados = persistirDados;

        }

        public RespostaAdicionarContato Processar(RequisicaoAdicionarContato requisicao)
        {
            ContextoAdicionarContato contexto = new()
            {
                Requisicao = requisicao
            };

            var result = _persistirDados.Processar(contexto);

            return new RespostaAdicionarContato() { Contexto = contexto, IdContato = result };
        }
    }
}