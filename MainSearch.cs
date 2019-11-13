using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWikipediaAPI
{
    class MainSearch
    {
        [JsonProperty("search")]
        public List<Search> Search { get; set; }
        
    }
}
