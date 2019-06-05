using System;
using System.Collections.Generic;
using System.Text;

namespace nlp.finance.vanguard.data
{
    public interface ICategory
    {
        string name { get; set; }
        int weight { get; set; }
        ICollection<string> matched_words { get; set; }
    }
}
