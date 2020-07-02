using CaulculoMonetarioApi.Negocio.Dto;
using CaulculoMonetarioApi.Negocio.Interfaces;
using CaulculoMonetarioApi.Negocio.Servicos;
using Moq;
using NUnit.Framework;

namespace CalculoMonetarioApi.Teste.Servico
{
    public class ConsumindoApiGitHubServicoTeste
    {
        private ConsumindoApiGitHubServico servico;

        private Mock<IConsumindoApiGitHubRepositorio> repositorioMock;

        [SetUp]
        public void Setup()
        {
            repositorioMock = new Mock<IConsumindoApiGitHubRepositorio>();

            repositorioMock.Setup(r => r.ObterUrlProjetoGitHub(It.IsAny<string>())).Returns(RepositorioDtoMock);

            servico = new ConsumindoApiGitHubServico(repositorioMock.Object);
        }

        [Test]
        public void ObterRepositorioGitHub_Retorna_RepositorioDto()
        {
            var repositorio = RepositorioDtoMock();
            var resultado = servico.ObterUrlProjetoGitHub();

            Assert.AreEqual(repositorio.UrlRepositorio, resultado.UrlRepositorio);
            Assert.AreEqual(repositorio.Language, resultado.Language);
            Assert.AreEqual(repositorio.Name, resultado.Name);
        }

        private RepositorioDto RepositorioDtoMock()
        {
           return new RepositorioDto()
            {
                Language = "C#",               
                Name = "CalculoMonetario",
                UrlRepositorio = "www.github.com.br"
            };
        }
    }

    }
