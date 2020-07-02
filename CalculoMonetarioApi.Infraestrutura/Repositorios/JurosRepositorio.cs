using CaulculoMonetarioApi.Negocio.Constantes;
using CaulculoMonetarioApi.Negocio.Interfaces;
using System.Threading.Tasks;

namespace CalculoMonetarioApi.Infraestrutura.Repositorios
{
    public class JurosRepositorio : IJurosRepositorio
    {
        private readonly IRequestRepositorio<decimal> _requestRepositorio;

        public JurosRepositorio(IRequestRepositorio<decimal> requestRepositorio)
        {
            _requestRepositorio = requestRepositorio;
        }

        public async Task<decimal> ObterJurosAsync()
        {
            var client = _requestRepositorio.CreateClient();

            return  await _requestRepositorio.Execute(client, EnvConstants.URI_JUROS);        
        }
    }
}
