using TechChallenge_1.Domain.Entidades.Contato;

namespace TechChallenge_1.Domain.Repositorio
{
    public interface IRepositorioContato
    {
        Task<Guid> SalvarContatoAsync(ContatosVO contato);

        Task<List<ContatosVO>> BuscarPorRegiaoAsync(short regiao);

        Task<bool> RemoverContatoAsync(Guid id);
    }
}