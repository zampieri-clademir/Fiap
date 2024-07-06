using AutoMapper;
using Moq;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_1.Application.Features.Contato.RemoverContato;
using TechChallenge_1.Domain.Features.RemoverContato.Modulos.Execucao;
using TechChallenge_1.Domain.Features.RemoverContato.Requisicao;

using TechChallenge_1.Domain.Features.RemoverContato.Resposta;

namespace TechChallenge_1.Application.Test.RemoverContato
{
    public class RemoverContatoHandlerTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IExecucaoRemoverContato> _fluxoRemoverContatoMock;
        private RemoverContatoHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _fluxoRemoverContatoMock = new Mock<IExecucaoRemoverContato>();
            _handler = new RemoverContatoHandler(_mapperMock.Object, _fluxoRemoverContatoMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsTrue()
        {
            // Arrange
            var command = new RemoverContatoCommand { IdContato = Guid.NewGuid().ToString() };
            var requisicao = new RequisicaoRemoverContato { IdContato = Guid.Parse(command.IdContato) };
            var resposta = new RespostaRemoverContato { Successo = true };

            _mapperMock.Setup(m => m.Map<RemoverContatoCommand, RequisicaoRemoverContato>(command)).Returns(requisicao);
            _fluxoRemoverContatoMock.Setup(f => f.Processar(requisicao)).Returns(resposta);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsFalse()
        {
            // Arrange
            var command = new RemoverContatoCommand { IdContato = Guid.NewGuid().ToString() };
            var requisicao = new RequisicaoRemoverContato { IdContato = Guid.Parse(command.IdContato) };
            var resposta = new RespostaRemoverContato { Successo = false };

            _mapperMock.Setup(m => m.Map<RemoverContatoCommand, RequisicaoRemoverContato>(command)).Returns(requisicao);
            _fluxoRemoverContatoMock.Setup(f => f.Processar(requisicao)).Returns(resposta);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
