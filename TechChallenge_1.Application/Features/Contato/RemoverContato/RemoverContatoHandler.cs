using AutoMapper;

using MediatR;

using TechChallenge_1.Domain.Features.RemoverContato.Modulos.Execucao;
using TechChallenge_1.Domain.Features.RemoverContato.Requisicao;
using TechChallenge_1.Domain.Features.RemoverContato.Resposta;

namespace TechChallenge_1.Application.Features.Contato.RemoverContato
{
    public class RemoverContatoHandler : IRequestHandler<RemoverContatoCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IExecucaoRemoverContato _fluxoAddContato;

        public RemoverContatoHandler(IMapper mapper, IExecucaoRemoverContato fluxoAddContato)
        {
            _fluxoAddContato = fluxoAddContato;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RemoverContatoCommand request, CancellationToken cancellationToken)
        {
            var requisicao = _mapper.Map<RemoverContatoCommand, RequisicaoRemoverContato>(request);

            var resposta = await ExecutarFluxoProcessamento(requisicao);

            return resposta.Successo;
        }

        private async Task<RespostaRemoverContato> ExecutarFluxoProcessamento(RequisicaoRemoverContato requisicao)
        {
            var resposta = _fluxoAddContato.Processar(requisicao);

            return await Task.FromResult(resposta);
        }
    }
}
