using TechChallenge_1.Domain.Features.RemoverContato.Contexto;
using TechChallenge_1.Domain.Repositorio;

namespace TechChallenge_1.Domain.Features.RemoverContato.Modulos.PersistirDados
{
    /// <summary>
    /// Classe responsável por acessar o repositório e efetuar as transasões no banco.
    /// </summary>
    public class PersistirDadosRemoverContatoImpl : IPersistirDadosRemoverContato
    {
        IRepositorioContato _repositorio;

        public PersistirDadosRemoverContatoImpl(IRepositorioContato repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Processar(ContextoRemoverContato contexto)
        {
            return _repositorio.RemoverContatoAsync(contexto.Requisicao.IdContato).Result;
        }
    }
}
