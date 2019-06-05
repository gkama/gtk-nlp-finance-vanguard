using System;
using System.Collections.Generic;
using System.Linq;

using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public static class ExtensionMethods
    {
        public static void AddIfNotNull(this List<object> categories, object value)
        {
            if (value != null) categories.Add(value);
        }

        public static void AddCategory(this List<ICategory> categories, string model_name, string value)
        {
            var category = categories
                .FirstOrDefault(x => x.name == model_name);

            if (category != null && category.matched_words.Contains(value, StringComparer.OrdinalIgnoreCase))
                category.total_weight++;
            else
            {
                var new_category = new Category() { name = model_name };

                new_category.matched_words.Add(value);
                new_category.total_weight++;

                categories.Add(new_category);
            }
        }
    }
}
