using CaulculoMonetarioApi.Negocio.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculoMonetarioApi.Infraestrutura.Repositorios
{
    public class RequestRepositorio<T> : IRequestRepositorio<T> where T : new()
    {
        
        public HttpClient CreateClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<T> Execute(HttpClient client, string uri)
        {
            var response =  client.GetStreamAsync(uri); 

            var resultResponse = await JsonSerializer.DeserializeAsync<T>(await response);

            return resultResponse; 
        }
    }
}
