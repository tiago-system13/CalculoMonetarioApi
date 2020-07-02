using System.Threading.Tasks;

namespace CaulculoMonetarioApi.Negocio.Interfaces
{
    public interface IJurosRepositorio
    {
        Task<decimal> ObterJurosAsync();
    }
}
