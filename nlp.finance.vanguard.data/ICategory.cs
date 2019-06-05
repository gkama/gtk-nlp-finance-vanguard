using System;
using System.Collections.Generic;
using System.Text;

namespace nlp.finance.vanguard.data
{
    public interface ICategory
    {
        string name { get; set; }
        int total_weight { get; set; }
        ICollection<IMatched> matched { get; set; }
    }

    public interface IMatched
    {
        string value { get; set; }
        int weight { get; set; }
    }
}
