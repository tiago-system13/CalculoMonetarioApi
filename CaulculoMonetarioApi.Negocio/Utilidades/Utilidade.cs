using System;
using System.Collections.Generic;
using System.Text;

namespace CaulculoMonetarioApi.Negocio.Utilidades
{
    public static class Utilidade
    {
        public static decimal TruncateDecimail(this decimal value, int decimalPlaces)
        {
            if (decimalPlaces < 0)
                throw new ArgumentException("decimalPlaces deve ser maior ou igual a 0.");

            var modifier = Convert.ToDecimal(0.5 / Math.Pow(10, decimalPlaces));
            return Math.Round(value >= 0 ? value - modifier : value + modifier, decimalPlaces);
        }
    }
}
