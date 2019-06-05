﻿using System;
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

            if (category != null
                && category.matched.FirstOrDefault(x => string.Compare(x.value, value, true) == 0) != null)
            {
                category.matched.FirstOrDefault(x => string.Compare(x.value, value, true) == 0).weight++;
                category.total_weight++;
            }
            else if (category != null
                && category.matched.FirstOrDefault(x => string.Compare(x.value, value, true) != 0) != null)
            {
                var new_matched = new Matched() { value = value };

                new_matched.weight++;
                category.matched.Add(new_matched);
                category.total_weight++;
            }
            else
            {
                var new_category = new Category() { name = model_name };
                var new_matched = new Matched() { value = value };

                new_matched.weight++;
                new_category.matched.Add(new_matched);
                new_category.total_weight++;

                categories.Add(new_category);
            }
        }


        public static List<string> Tokenize(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new List<string>();

            var words = input.Split(ModelsSettings.delimiters,
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var found = new List<string>();

            words.ForEach(x =>
            {
                var x_lower = x.ToLower();

                if (!ModelsSettings.stop_words.Contains(x_lower))
                    found.Add(x);
            });

            return found;
        }
    }
}
