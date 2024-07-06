using Moq;

using NUnit.Framework;

using TechChallenge_1.Domain.Features.RemoverContato.Contexto;
using TechChallenge_1.Domain.Features.RemoverContato.Modulos.PersistirDados;
using TechChallenge_1.Domain.Features.RemoverContato.Requisicao;
using TechChallenge_1.Domain.Repositorio;

namespace TechChallenge_1.Domain.Test.RemoverContato
{
    [TestFixture]
    public class PersistirDadosRemoverContatoImplTests
    {
        private Mock<IRepositorioContato> _repositorioMock;
        private PersistirDadosRemoverContatoImpl _persistirDados;

        [SetUp]
        public void SetUp()
        {
            _repositorioMock = new Mock<IRepositorioContato>();
            _persistirDados = new PersistirDadosRemoverContatoImpl(_repositorioMock.Object);
        }

        [Test]
        public void Processar_ValidContext_ReturnsTrue()
        {
            // Arrange
            var contexto = new ContextoRemoverContato
            {
                Requisicao = new RequisicaoRemoverContato
                {
                    IdContato = Guid.NewGuid()
                }
            };

            _repositorioMock.Setup(r => r.RemoverContatoAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            // Act
            var result = _persistirDados.Processar(contexto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Processar_ValidContext_ReturnsFalse()
        {
            // Arrange
            var contexto = new ContextoRemoverContato
            {
                Requisicao = new RequisicaoRemoverContato
                {
                    IdContato = Guid.NewGuid()
                }
            };

            _repositorioMock.Setup(r => r.RemoverContatoAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            // Act
            var result = _persistirDados.Processar(contexto);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
