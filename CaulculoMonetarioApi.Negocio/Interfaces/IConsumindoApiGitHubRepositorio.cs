using CaulculoMonetarioApi.Negocio.Dto;

namespace CaulculoMonetarioApi.Negocio.Interfaces
{
    public interface IConsumindoApiGitHubRepositorio
    {
        RepositorioDto ObterUrlProjetoGitHub(string repositorio);
    }
}
