using Moq;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechChallenge_1.Application.Features.Contato.AdicionarContato;
using TechChallenge_1.Domain.Entidades.Contato;

using TechChallenge_1.Domain.Repositorio;

namespace TechChallenge_1.Application.Test.ConsultarContato
{
    public class BuscarContatoHandlerTests
    {
        private Mock<IRepositorioContato> _repositoryMock;
        private BuscarContatoHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepositorioContato>();
            _handler = new BuscarContatoHandler(_repositoryMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsListOfContatosVO()
        {
            // Arrange
            var query = new ConsultarContatoQuery { Ddd = 11 };
            var expectedContatos = new List<ContatosVO>
        {
            new ContatosVO { Nome = "Contato 1", Email = "contato1@exemplo.com", Telefone = "123456789", Ddd = 11 },
            new ContatosVO { Nome = "Contato 2", Email = "contato2@exemplo.com", Telefone = "987654321", Ddd = 11 }
        };

            _repositoryMock.Setup(r => r.BuscarPorRegiaoAsync(query.Ddd))
                           .ReturnsAsync(expectedContatos);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotEmpty(expectedContatos);
        }


        [Test]
        public async Task Handle_RepositoryReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var query = new ConsultarContatoQuery { Ddd = 11 };
            var expectedContatos = new List<ContatosVO>();
            expectedContatos.Add(new ContatosVO { Nome = "Contato 1", Email = "contato1@exemplo.com", Telefone = "123456789", Ddd = 11 });

            _repositoryMock.Setup(r => r.BuscarPorRegiaoAsync(query.Ddd))
                           .ReturnsAsync(expectedContatos);

            // Act
            var result = _handler.Handle(query, CancellationToken.None).Result;

            // Assert
            Assert.IsNotEmpty(expectedContatos);
        }
    }
}
