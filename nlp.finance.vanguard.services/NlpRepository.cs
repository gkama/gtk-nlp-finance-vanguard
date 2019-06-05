using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Logging;

using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public class NlpRepository<T> : INlpRepository<T> 
        where T : class
    {
        public IModel<T> model { get; }
        public ILogger log { get; }

        public NlpRepository(IModel<T> model, ILogger<NlpRepository<T>> log)
        {
            this.model = model;
            this.log = log;
        }

        public IEnumerable<object> Categorize(string content)
        {
            var models = new Stack<T>(model.children);
            var categories = new List<object>();

            while (models.Any())
            {
                var m = models.Pop() as IModel<T>;

                content.Split(' ').ToList().ForEach(x =>
                {
                    categories.AddIfNotNull(BinarySearchDetails(x, m));
                });

                if (m.children.Any())
                    m.children.ToList().ForEach(x =>
                    {
                        models.Push(x);
                    });
            }

            return categories;
        }

        private object BinarySearchDetails(string value, IModel<T> model)
        {
            var low = 0;
            var high = model.details_split.Count() - 1;
            var mid = 0;
            var details_array = model.details_split as string[];

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (string.Compare(value, details_array[mid], true) < 0)
                    high = mid - 1;
                else if (string.Compare(value, details_array[mid], true) > 0)
                    low = mid + 1;
                else
                    return new { category = model.name, value = value };
            }

            return null;
        }
    }
}
