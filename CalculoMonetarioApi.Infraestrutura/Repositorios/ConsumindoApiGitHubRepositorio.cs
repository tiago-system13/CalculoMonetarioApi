using CaulculoMonetarioApi.Negocio.Constantes;
using CaulculoMonetarioApi.Negocio.Dto;
using CaulculoMonetarioApi.Negocio.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CalculoMonetarioApi.Infraestrutura.Repositorios
{
    public class ConsumindoApiGitHubRepositorio : IConsumindoApiGitHubRepositorio
    {
        private readonly IRequestRepositorio<List<RepositorioDto>> _requestRepositorio;

        public ConsumindoApiGitHubRepositorio(IRequestRepositorio<List<RepositorioDto>> requestRepositorio)
        {
            _requestRepositorio = requestRepositorio;
        }
        public RepositorioDto ObterUrlProjetoGitHub(string nameRepositorio)
        {

            var httpClientInstance = _requestRepositorio.CreateClient();
            httpClientInstance.DefaultRequestHeaders.Accept.Clear();
            httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
            httpClientInstance.DefaultRequestHeaders.Add("User-Agent", "Calculo-Monetario");

            var request = new HttpRequestMessage(HttpMethod.Get, $"{EnvConstants.BASE_URL_GITHUB}/users/{EnvConstants.USUARIO_PADRAO}/repos");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");

            var jsonString = httpClientInstance.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

            var resultadoResponse = JsonConvert.DeserializeObject<List<RepositorioDto>>(jsonString);

            RepositorioDto repositorio = null;

            if (resultadoResponse != null)
            {
                repositorio = resultadoResponse.FirstOrDefault(r => r.Name.Trim().Equals(nameRepositorio));

            }

            return repositorio;
        }
    }
}
