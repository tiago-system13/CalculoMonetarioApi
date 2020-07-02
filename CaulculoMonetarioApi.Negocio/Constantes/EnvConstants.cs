using System;

namespace CaulculoMonetarioApi.Negocio.Constantes
{
    public static class EnvConstants
    {
        public static readonly string TAXA_JUROS = Environment.GetEnvironmentVariable("TAXA_JUROS");
        public static readonly string URI_JUROS = Environment.GetEnvironmentVariable("URI_JUROS");
        public static readonly string BASE_URL_GITHUB = Environment.GetEnvironmentVariable("BASE_URL_GITHUB");
        public static readonly string USUARIO_PADRAO = Environment.GetEnvironmentVariable("USUARIO_PADRAO");
        public static readonly string NOME_REPOSITORIO = Environment.GetEnvironmentVariable("NOME_REPOSITORIO"); 
    }
}
