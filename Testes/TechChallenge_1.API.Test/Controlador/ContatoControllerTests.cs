using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NDD.Portal.NFe.Application.Features.Emissao.Queries.BuscarDocumento;

using NUnit.Framework;

using TechChallenge_1.API.Features.Contato;
using TechChallenge_1.Application.Features.Contato.AdicionarContato;
using TechChallenge_1.Application.Features.Contato.RemoverContato;
using TechChallenge_1.Domain.Entidades.Contato;

namespace TechChallenge_1.API.Test.Controlador
{
    [TestFixture]
    public class ContatoControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IMapper> _mapperMock;
        private ContatoController _controller;

        [SetUp]
        public void SetUp()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ContatoController(_mediatorMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task AdicionarContato_ValidRequest_ReturnsOk()
        {
            // Arrange
            var contatoCommand = new AdicionarContatoCommand { Nome = "Teste", Email = "teste@exemplo.com", Telefone = "123456789", Ddd = 11 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AdicionarContatoCommand>(), default)).ReturnsAsync(Guid.NewGuid());

            // Act
            var result = await _controller.AdicionarContato(contatoCommand);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOf<Guid>(okResult.Value);
        }

        [Test]
        public async Task AdicionarContato_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Nome", "O nome é obrigatório");
            var contatoCommand = new AdicionarContatoCommand();

            // Act
            var result = await _controller.AdicionarContato(contatoCommand);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task RemoverContato_ValidRequest_ReturnsOk()
        {
            // Arrange
            var contatoCommand = new RemoverContatoCommand { IdContato = Guid.NewGuid().ToString() };
            _mediatorMock.Setup(m => m.Send(It.IsAny<RemoverContatoCommand>(), default)).ReturnsAsync(true);

            // Act
            var result = await _controller.RemoverContato(contatoCommand);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task RemoverContato_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("ContatoId", "O ID do contato é obrigatório");
            var contatoCommand = new RemoverContatoCommand();

            // Act
            var result = await _controller.RemoverContato(contatoCommand);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task BuscarContato_ValidRequest_ReturnsOk()
        {
            // Arrange
            var query = new BuscarContatoQuery { Ddd = 49 };
            var expectedResult = new List<ContatosVO>();
            _mediatorMock.Setup(m => m.Send(It.IsAny<BuscarContatoQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.BuscarContato(query);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(expectedResult, okResult.Value);
        }

        [Test]
        public async Task BuscarContato_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Nome", "O nome é obrigatório");
            var query = new BuscarContatoQuery();

            // Act
            var result = await _controller.BuscarContato(query);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}
