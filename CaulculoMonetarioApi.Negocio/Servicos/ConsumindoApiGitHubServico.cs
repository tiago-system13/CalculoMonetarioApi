using CaulculoMonetarioApi.Negocio.Constantes;
using CaulculoMonetarioApi.Negocio.Dto;
using CaulculoMonetarioApi.Negocio.Interfaces;
using CaulculoMonetarioApi.Negocio.Servicos.Interfaces;

namespace CaulculoMonetarioApi.Negocio.Servicos
{
    public class ConsumindoApiGitHubServico : IConsumindoApiGitHubServico
    {
        private readonly IConsumindoApiGitHubRepositorio _consumindoApiGitHubRepositorio;

        public ConsumindoApiGitHubServico(IConsumindoApiGitHubRepositorio consumindoApiGitHubRepositorio)
        {
            _consumindoApiGitHubRepositorio = consumindoApiGitHubRepositorio;
        }
        public RepositorioDto ObterUrlProjetoGitHub()
        {
          return  _consumindoApiGitHubRepositorio.ObterUrlProjetoGitHub(EnvConstants.NOME_REPOSITORIO);
           
        }
    }
}
