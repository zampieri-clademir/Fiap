using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using NDD.Portal.NFe.Application.Features.Emissao.Queries.BuscarDocumento;

using TechChallenge_1.API.Exceptions;
using TechChallenge_1.Application.Features.Contato.AdicionarContato;
using TechChallenge_1.Application.Features.Contato.RemoverContato;

namespace TechChallenge_1.API.Features.Contato
{
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContatoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adiciona novo contato
        /// </summary>
        /// <param name="contatoCommand">Contém as informações necessarias para criar um contato</param>
        /// <response code="200">Success, Chamada realizada com sucesso.</response>
        /// <response code="400">Bad Request, chamada inválida.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionPayload), StatusCodes.Status400BadRequest)]
        [HttpPost("AdicionarContato")]
        public async Task<IActionResult> AdicionarContato([FromBody] AdicionarContatoCommand contatoCommand)
        {
            if (contatoCommand == null)
                throw new ArgumentNullException("O parâmetro não pode ser nulo");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var executarAcaoMediador = () => _mediator.Send(contatoCommand);

            var resultado = await executarAcaoMediador();

            if (resultado == Guid.Empty)
                return BadRequest("Erro no processamento");

            return Ok(resultado);
        }

        /// <summary>
        /// Remove contato pelo identificador
        /// </summary>
        /// <param name="contatoCommand">Contém as informações necessarias para remover um contato</param>
        /// <response code="200">Success, Chamada realizada com sucesso.</response>
        /// <response code="400">Bad Request, chamada inválida.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExceptionPayload), StatusCodes.Status400BadRequest)]
        [HttpPost("RemoverContato")]
        public async Task<IActionResult> RemoverContato([FromBody] RemoverContatoCommand contatoCommand)
        {
            if (contatoCommand == null)
                throw new ArgumentNullException("O parâmetro não pode ser nulo");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var executarAcaoMediador = () => _mediator.Send(contatoCommand);

            var sucesso = await executarAcaoMediador();

            if (sucesso == false)
                return BadRequest();

            return Ok();
        }

        /// <summary>
        /// Busca Contato pelo filtro informado
        /// </summary>
        /// <param name="filtro">Filtro especificado pelo cliente</param>
        /// <response code="200">Success, Chamada realizada com sucesso</response>
        /// <response code="400">Bad Request, chamada inválida</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoContatosViewModel), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [Route("buscarContato")]
        public async Task<IActionResult> BuscarContato(BuscarContatoQuery filtro)
        {
            if (filtro == null)
                throw new ArgumentNullException("O parâmetro não pode ser nulo");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(filtro);

            return Ok(result);
        }
    }
}
