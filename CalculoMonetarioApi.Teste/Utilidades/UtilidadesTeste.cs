using CaulculoMonetarioApi.Negocio.Utilidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoMonetarioApi.Teste.Utilidades
{
    public class UtilidadesTeste
    {
        [TestCase(100.09890, 2, 100.09)]
        public void TruncateDecimail_CasaDecimalMenorQueZero(decimal valorInicial, int casaDecimal, decimal resultado)
        {
            var valorCalculado = Utilidade.TruncateDecimail(valorInicial, casaDecimal);
            Assert.AreEqual(resultado, valorCalculado);
        }

        [TestCase(100, -1)]
        public void TruncateDecimail_Exception_CasaDecimalMenorQueZero(decimal valorInicial, int casaDecimal)
        {
            var ex = Assert.Throws<ArgumentException>(() => Utilidade.TruncateDecimail(valorInicial, casaDecimal));
            Assert.That(ex.Message, Is.EqualTo("decimalPlaces deve ser maior ou igual a 0."));
        }
    }
}
