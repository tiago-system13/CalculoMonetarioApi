using CaulculoMonetarioApi.Negocio.Interfaces;
using CaulculoMonetarioApi.Negocio.Servicos;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CalculoMonetarioApi.Teste.Servico
{
    public class CalculaJurosServicoTeste
    {
        private CalculaJurosServico servico;
        private Mock<IJurosRepositorio> repositorioMock;

        [SetUp]
        public void Setup()
        {
            repositorioMock = new Mock<IJurosRepositorio>();
            var juros = Task.FromResult(0.01M);

            repositorioMock.Setup(j => j.ObterJurosAsync()).Returns(juros);
            servico = new CalculaJurosServico(repositorioMock.Object);
        }

        [TestCase(100, 1, 101)]
        [TestCase(100, 2, 102)]
        [TestCase(100, 3, 103.03)]
        [TestCase(100, 4, 104.06)]
        [TestCase(100, 5, 105.1)]
        [TestCase(100, 6, 106.15)]
        [TestCase(100, 7, 107.21)]
        [TestCase(100, 8, 108.28)]
        [TestCase(100, 9, 109.36)]
        [TestCase(100, 10, 110.46)]
        [TestCase(100, 11, 111.56)]
        [TestCase(100, 12, 112.68)]
        public void CalcularJuros_ComValorIniciaETempo_RetornaValorFinal(decimal valorInicial, int tempo, decimal valorFinal)
        {
            var resultado = servico.CalcularJuros(tempo, valorInicial);

            Assert.AreEqual(valorFinal, resultado);
        }

        [TestCase(100.09890, 2, 100.09)]
        public void TruncateDecimail_CasaDecimalMenorQueZero(decimal valorInicial, int casaDecimal, decimal resultado)
        {
            var valorCalculado = servico.TruncateDecimail(valorInicial, casaDecimal);
            Assert.AreEqual(resultado, valorCalculado);
        }

        [TestCase(100, -1)]
        public void TruncateDecimail_Exception_CasaDecimalMenorQueZero(decimal valorInicial, int casaDecimal)
        {
            var ex = Assert.Throws<ArgumentException>(() => servico.TruncateDecimail(valorInicial, casaDecimal));
            Assert.That(ex.Message, Is.EqualTo("decimalPlaces deve ser maior ou igual a 0."));
        }
    }
}
