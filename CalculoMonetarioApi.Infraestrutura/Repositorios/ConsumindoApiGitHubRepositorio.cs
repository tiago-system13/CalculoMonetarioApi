using CaulculoMonetarioApi.Negocio.Constantes;
using CaulculoMonetarioApi.Negocio.Dto;
using CaulculoMonetarioApi.Negocio.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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

            var jsonString = _requestRepositorio.GetVsAsync(httpClientInstance, $"{EnvConstants.BASE_URL_GITHUB}/users/{EnvConstants.USUARIO_PADRAO}/repos").Result;

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
