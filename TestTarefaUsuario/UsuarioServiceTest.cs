using Xunit;
using Moq;
using System;
using TPC.TarefaUsuario.API.Core.Repositories.Interface;
using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Services;

namespace TestTarefaUsuario
{
public class UsuarioServiceTest
    {
        [Fact]
        public void GetUsuarioById_ValidId_ReturnsUser()
        {
            // Arrange
            var mockRepo = new Mock<IUsuarioRepository>();
            mockRepo.Setup(repo => repo.FindById(1))
                .Returns(new Usuario { Id = 1, NomeUsuario = "MeuNomeUsuarioTeste", Email="testepara1234@yahoo.com.br" });

            var service = new UsuarioService(mockRepo.Object);

            // Act
            var user = service.FindById(1);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(1, user.Id);
            Assert.Equal("MeuNomeUsuarioTeste", user.NomeUsuario);
        }

        [Fact]
        public void GetUsuarioById_InvalidId_ThrowsException()
        {
            // Arrange
            var mockRepo = new Mock<IUsuarioRepository>();
            var service = new UsuarioService(mockRepo.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.FindById(0));
        }

        [Fact]
        public void GetUsuarioById_RepositoryReturnsNull_ReturnsNull()
        {
            // Arrange
            var mockRepo = new Mock<IUsuarioRepository>();
            mockRepo.Setup(repo => repo.FindById(1)).Returns((Usuario)null);
            var service = new UsuarioService(mockRepo.Object);

            // Act
            var user = service.FindById(1);

            // Assert
            Assert.Null(user);
        }

    }

}
