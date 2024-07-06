using AutoMapper;

using MediatR;

using TechChallenge_1.Domain.Features.AdicionarContato.Modulos.Execucao;
using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;
using TechChallenge_1.Domain.Features.AdicionarContato.Resposta;

namespace TechChallenge_1.Application.Features.Contato.AdicionarContato
{
    public class AdicionarContatoHandler : IRequestHandler<AdicionarContatoCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IExecucaoAdicionarContato _fluxoAddContato;

        public AdicionarContatoHandler(IMapper mapper, IExecucaoAdicionarContato fluxoAddContato)
        {
            _fluxoAddContato = fluxoAddContato;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AdicionarContatoCommand request, CancellationToken cancellationToken)
        {
            var requisicao = _mapper.Map<AdicionarContatoCommand, RequisicaoAdicionarContato>(request);

            var resposta = await ExecutarFluxoProcessamento(requisicao);

            return resposta.IdContato;
        }

        private async Task<RespostaAdicionarContato> ExecutarFluxoProcessamento(RequisicaoAdicionarContato requisicao)
        {
            var resposta = _fluxoAddContato.Processar(requisicao);

            return await Task.FromResult(resposta);
        }
    }
}
