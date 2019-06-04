using System;
using System.Collections.Generic;

namespace nlp.finance.vanguard.data
{
    public class VanguardModel : IModel<VanguardModel>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string details { get; set; }

        public IEnumerable<VanguardModel> children { get; set; } = new List<VanguardModel>();
    }
}
