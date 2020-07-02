using CaulculoMonetarioApi.Negocio.Constantes;
using CaulculoMonetarioApi.Negocio.Dto;
using CaulculoMonetarioApi.Negocio.Interfaces;
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
           var client = _requestRepositorio.CreateClient();

           var resultResponse =  _requestRepositorio.Execute(client, $"{EnvConstants.BASE_URL_GITHUB}/users/{EnvConstants.USUARIO_PADRAO}/repos").Result;

            RepositorioDto repositorio = null;

            if (resultResponse != null)
            {
                repositorio = resultResponse.FirstOrDefault(r => r.Name.Trim().Equals(nameRepositorio));

            }

            return repositorio;
        }
    }
}
