using TechChallenge_1.Domain.Entidades.Contato;
using TechChallenge_1.Domain.Features.AdicionarContato.Contexto;
using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;
using TechChallenge_1.Domain.Repositorio;

namespace TechChallenge_1.Domain.Features.AdicionarContato.Modulos.PersistirDados
{
    /// <summary>
    /// Classe responsável por acessar o repositório e efetuar as transasões no banco.
    /// </summary>
    public class PersistirDadosAdicionarContatoImpl : IPersistirDadosAdicionarContato
    {
        IRepositorioContato _repositorio;

        public PersistirDadosAdicionarContatoImpl(IRepositorioContato repositorio)
        {
            _repositorio = repositorio;
        }
        public Guid Processar(ContextoAdicionarContato contexto)
        {
            var contato = new ContatosVO()
            {
                Nome = contexto.Requisicao.Nome,
                Email = contexto.Requisicao.Email,
                Telefone = contexto.Requisicao.Telefone,
                Ddd = contexto.Requisicao.Ddd
            };

            return _repositorio.SalvarContatoAsync(contato).Result;
        }
    }
}
