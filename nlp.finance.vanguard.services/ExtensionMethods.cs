using System;
using System.Collections.Generic;
using System.Text;

namespace nlp.finance.vanguard.services
{
    public static class ExtensionMethods
    {
        public static void AddIfNotNull(this List<object> categories, object value)
        {
            if (value != null) categories.Add(value);
        }
    }
}
