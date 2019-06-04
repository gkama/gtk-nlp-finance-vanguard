using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace nlp.finance.vanguard.data
{
    public class VanguardModel : IModel<VanguardModel>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        [JsonIgnore] public IEnumerable<string> details_split => details.Split('|');
        public IEnumerable<VanguardModel> children { get; set; } = new List<VanguardModel>();
    }
}
