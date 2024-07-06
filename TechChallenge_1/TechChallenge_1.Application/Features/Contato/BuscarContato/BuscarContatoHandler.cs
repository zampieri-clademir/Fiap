using MediatR;

using NDD.Portal.NFe.Application.Features.Emissao.Queries.BuscarDocumento;

using TechChallenge_1.Domain.Entidades.Contato;
using TechChallenge_1.Domain.Repositorio;

namespace TechChallenge_1.Application.Features.Contato.AdicionarContato
{
    public class BuscarContatoHandler : IRequestHandler<BuscarContatoQuery, List<ContatosVO>>
    {
        private readonly IRepositorioContato _repository;
        public BuscarContatoHandler(IRepositorioContato repository)
        {
            _repository = repository;
        }

        public async Task<List<ContatosVO>> Handle(BuscarContatoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.BuscarPorRegiaoAsync(request.Ddd);
        }
    }
}
