using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CaulculoMonetarioApi.Negocio.Dto
{
    public class RepositorioDto
    {
        [JsonProperty(PropertyName = "html_url")]
        public string UrlRepositorio { get; set; }
        
        public string Name { get; set; }

        [DataMember]
        public string Language { get; set; }        
    }
}
