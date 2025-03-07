using Moq;
using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Repositories.Interface;
using TPC.TarefaUsuario.API.Core.Services;
using Xunit;

namespace TestTarefaUsuario
{
    public class TarefaServiceTest
    {

        [Fact]
        public void GetTarefaById_ValidId_ReturnsUser()
        {
            // Arrange
            var mockRepo = new Mock<ITarefaRepository>();
            mockRepo.Setup(repo => repo.FindById(1))
                .Returns(new Tarefa { Id = 1, Titulo = "TituloTarefaTeste", Descricao = "Teste de contrato.", StatusId= 1, UsuarioId=1 });

            var service = new TarefaService(mockRepo.Object);

            // Act
            var tarefa = service.FindById(1);

            // Assert
            Assert.NotNull(tarefa);
            Assert.Equal(1, tarefa.Id);
            Assert.Equal("TituloTarefaTeste", tarefa.Titulo);
        }

        [Fact]
        public void GetTarefaById_InvalidId_ThrowsException()
        {
            // Arrange
            var mockRepo = new Mock<ITarefaRepository>();
            var service = new TarefaService(mockRepo.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.FindById(0));
        }

        [Fact]
        public void GetTarefaById_RepositoryReturnsNull_ReturnsNull()
        {
            // Arrange
            var mockRepo = new Mock<ITarefaRepository>();
            mockRepo.Setup(repo => repo.FindById(1)).Returns((Tarefa)null);
            var service = new TarefaService(mockRepo.Object);

            // Act
            var user = service.FindById(1);

            // Assert
            Assert.Null(user);
        }

    }


}
