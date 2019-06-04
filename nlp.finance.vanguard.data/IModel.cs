using System;
using System.Collections;
using System.Collections.Generic;

namespace nlp.finance.vanguard.data
{
    public interface IModel<T> 
        where T : class
    {
        string id { get; set; }
        string name { get; set; }
        string details { get; set; }
        IEnumerable<string> details_split { get; }
        IEnumerable<T> children { get; set; }
    }
}
