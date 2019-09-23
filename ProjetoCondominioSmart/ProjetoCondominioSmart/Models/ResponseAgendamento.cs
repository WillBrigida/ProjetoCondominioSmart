using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCondominioSmart.Models
{
    public class ResponseAgendamento
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("recipients")]
        public int Recipients { get; set; }

        [JsonProperty("external_id")]
        public object ExternalId { get; set; }
    }
}
