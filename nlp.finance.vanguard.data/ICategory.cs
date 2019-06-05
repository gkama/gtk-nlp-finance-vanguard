using System;
using System.Collections.Generic;
using System.Text;

namespace nlp.finance.vanguard.data
{
    public interface ICategory
    {
        string name { get; set; }
        int total_weight { get; set; }
        ICollection<string> matched_words { get; set; }
    }
}
