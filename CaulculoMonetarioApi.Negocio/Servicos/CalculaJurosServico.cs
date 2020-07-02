using CaulculoMonetarioApi.Negocio.Interfaces;
using CaulculoMonetarioApi.Negocio.Servicos.Interfaces;
using System;

namespace CaulculoMonetarioApi.Negocio.Servicos
{
    public class CalculaJurosServico : ICalculaJurosServico
    {
        private readonly IJurosRepositorio _jurosRepositorio;
        private const int CASAS_DECIMAIS = 2;

        public CalculaJurosServico(IJurosRepositorio jurosRepositorio)
        {
            _jurosRepositorio = jurosRepositorio;
        }
        public decimal CalcularJuros(int tempo, decimal valorInicial)
        {
            var taxaDeJuros = _jurosRepositorio.ObterJurosAsync().Result;

            var juros = (double) (1 + taxaDeJuros);

            var montante = valorInicial * (decimal)Math.Pow(juros,tempo);

            return TruncateDecimail(montante, CASAS_DECIMAIS);
        }

        public decimal TruncateDecimail( decimal value, int decimalPlaces)
        {
            if (decimalPlaces < 0)
                throw new ArgumentException("decimalPlaces deve ser maior ou igual a 0.");

            var modifier = Convert.ToDecimal(0.5 / Math.Pow(10, decimalPlaces));
            return Math.Round(value >= 0 ? value - modifier : value + modifier, decimalPlaces);
        }
    }
}
