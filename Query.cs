using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfWikipediaAPI
{
    class Query
    {
        [JsonProperty("query")]
        public MainSearch query { get; set; }
    }
}
