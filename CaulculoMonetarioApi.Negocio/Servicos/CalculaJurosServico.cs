using CaulculoMonetarioApi.Negocio.Interfaces;
using CaulculoMonetarioApi.Negocio.Servicos.Interfaces;
using CaulculoMonetarioApi.Negocio.Utilidades;
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

            return Utilidade.TruncateDecimail(montante, CASAS_DECIMAIS);
        }

       
    }
}
