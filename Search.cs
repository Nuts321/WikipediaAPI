using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfWikipediaAPI
{
    class Search
    {
        [JsonProperty("pageid")]
        public int PageId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
