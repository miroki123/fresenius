using Domain.DTO;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Doenca;

namespace UnitTestProject
{
    [TestClass]
    public class DoencaServiceTest
    {
        [TestMethod]
        public void Inserir()
        {
            var mock = new Mock<DbSet<Tb_CID>>();
            var ctx = new Mock<ApplicationContext>();
            ctx.Setup(m => m.Model["Tb_CID"]).Returns(mock.Object);
            var repo = new Mock<CIDRepository>(ctx);

            var service = new DoencaService(repo.Object);

            var doenca = new DoencaDTO
            {
                Codigo = "cod001",
                Nome = "Osteoporose"
            };

            service.Inserir(doenca);

            mock.Verify(m => m.Add(It.IsAny<Tb_CID>()), Times.Once());
            ctx.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void ObterDoencas()
        {
            
        }

        [TestMethod]
        public void Alterar()
        {

        }

        [TestMethod]
        public void Remover()
        {

        }
    }
}
