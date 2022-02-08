using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PortalDataOwner.Dto
{
    public class Cliente
    {
        [JsonPropertyName("Codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("NomeFantasia")]
        public string NomeFantasia { get; set; }
    }
}
