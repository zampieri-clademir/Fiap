using AutoMapper;

using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechChallenge_1.Application.Features.Contato.AdicionarContato;
using TechChallenge_1.Domain.Features.AdicionarContato.Modulos.Execucao;
using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;
using TechChallenge_1.Domain.Features.AdicionarContato.Resposta;

namespace TechChallenge_1.Application.Test.AdicionarContato
{
    public class AdicionarContatoHandlerTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IExecucaoAdicionarContato> _fluxoAddContatoMock;
        private AdicionarContatoHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _fluxoAddContatoMock = new Mock<IExecucaoAdicionarContato>();
            _handler = new AdicionarContatoHandler(_mapperMock.Object, _fluxoAddContatoMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsGuid()
        {
            // Arrange
            var command = new AdicionarContatoCommand
            {
                Nome = "Teste Nome",
                Email = "teste@exemplo.com",
                Telefone = "123456789",
                Ddd = 11
            };

            var requisicao = new RequisicaoAdicionarContato
            {
                Nome = command.Nome,
                Email = command.Email,
                Telefone = command.Telefone,
                Ddd = command.Ddd
            };

            var resposta = new RespostaAdicionarContato
            {
                IdContato = Guid.NewGuid()
            };

            _mapperMock.Setup(m => m.Map<AdicionarContatoCommand, RequisicaoAdicionarContato>(It.IsAny<AdicionarContatoCommand>()))
                       .Returns(requisicao);

            _fluxoAddContatoMock.Setup(f => f.Processar(It.IsAny<RequisicaoAdicionarContato>()))
                                .Returns(resposta);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(resposta.IdContato, result);
        }
    }
}
