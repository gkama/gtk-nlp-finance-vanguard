using System;
using System.Collections;
using System.Collections.Generic;

namespace nlp.finance.vanguard.data
{
    public interface IModel<T> 
        where T : class
    {
        Guid id { get; set; }
        string name { get; set; }
        string details { get; set; }
        IEnumerable<T> children { get; set; }
    }
}
