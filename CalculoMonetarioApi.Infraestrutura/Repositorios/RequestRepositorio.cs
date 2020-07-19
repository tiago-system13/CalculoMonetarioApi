using CaulculoMonetarioApi.Negocio.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
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
            client.DefaultRequestHeaders.ConnectionClose = false;
            client.DefaultRequestHeaders.Add("User-Agent", "Calculo-Monetario");

            return client;
        }

        public async Task<T> Execute(HttpClient client, string uri)
        {
            var response =  client.GetStreamAsync(uri); 

            var resultResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(await response);

            return resultResponse; 
        }     
        
        public async Task<string> GetVsAsync(HttpClient httpClientInstance,string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Accept", "application/vnd.github.v3+json");

            return await httpClientInstance.SendAsync(request).Result.Content.ReadAsStringAsync();
        }

    }
}
