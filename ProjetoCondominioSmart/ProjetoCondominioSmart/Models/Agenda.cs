using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCondominioSmart.Models
{
   
    public class Agenda
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("contents")]
        public Contents Contents { get; set; }

        [JsonProperty("headings")]
        public Contents Headings { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("included_segments")]
        public string[] IncludedSegments { get; set; }

        [JsonProperty("send_after")]
        public string SendAfter { get; set; }
    }
    public partial class Contents
    {
        [JsonProperty("en")]
        public string En { get; set; }
    }
}
 