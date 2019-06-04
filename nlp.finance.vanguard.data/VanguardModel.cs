using System;
using System.Collections.Generic;

namespace nlp.finance.vanguard.data
{
    public class VanguardModel : IModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string details { get; set; }

        public ICollection<VanguardModel> children { get; set; } = new List<VanguardModel>();
    }
}
