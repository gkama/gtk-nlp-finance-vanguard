using System;
using System.Collections.Generic;
using System.Linq;

namespace nlp.finance.vanguard.data
{
    public class Category : ICategory
    {
        [Newtonsoft.Json.JsonProperty("category")]
        public string name { get; set; }
        public int total_weight
        {
            get
            {
                var t = 0;
                matched.ToList().ForEach(x =>
                {
                    t += x.weight;
                });

                return t;
            }
        }
        public ICollection<IMatched> matched { get; set; } = new List<IMatched>();
    }

    public class Matched : IMatched
    {
        public string value { get; set; }
        public int weight { get; set; } = 0;
    }
}
