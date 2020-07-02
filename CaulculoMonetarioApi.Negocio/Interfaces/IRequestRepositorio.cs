using System.Net.Http;
using System.Threading.Tasks;

namespace CaulculoMonetarioApi.Negocio.Interfaces
{
    public interface IRequestRepositorio<T> where T : new()
    {
        HttpClient CreateClient();

        Task<T> Execute(HttpClient client, string uri);       
    }
}
