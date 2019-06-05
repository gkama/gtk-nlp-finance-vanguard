using System;
using System.Collections.Generic;
using System.Linq;

namespace nlp.finance.vanguard.data
{
    public class Category : ICategory
    {
        [Newtonsoft.Json.JsonProperty("category")]
        public string name { get; set; }
        public int weight { get; set; } = 0;
        public ICollection<string> matched_words { get; set; } = new List<string>();
    }
}
