using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PortalDataOwner.Dto
{
    public class Result
    {
        [JsonPropertyName("Erro")]
        public int Erro { get; set; } = 0;

        [JsonPropertyName("Mensagem")]
        public string Mensagem { get; set; }

        [JsonPropertyName("Result")]
        public object Item { get; set; }
    }
}
