using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IEnumerable<ICategory> Categorize(string content)
        {
            var models = new Stack<T>(model.children);
            var categories = new List<ICategory>();

            var sw = new Stopwatch();

            sw.Start();
            while (models.Any())
            {
                var m = models.Pop() as IModel<T>;

                //TODO: add words vs. phrases (containing spaces)
                content.Tokenize().ForEach(x =>
                {
                    BinarySearchDetails(x, m, ref categories);
                });

                if (m.children.Any())
                    m.children.ToList().ForEach(x =>
                    {
                        models.Push(x);
                    });
            }
            sw.Stop();

            log.LogInformation($"categorization took {sw.Elapsed.TotalMilliseconds * 1000} μs (microseconds)");

            return categories;
        }

        private void BinarySearchDetails(string value, IModel<T> model, ref List<ICategory> categories)
        {
            var low = 0;
            var mid = 0;
            var high = model.details_split.Count() - 1;
            var details_array = model.details_split as string[];

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (string.Compare(value, details_array[mid], true) < 0)
                    high = mid - 1;
                else if (string.Compare(value, details_array[mid], true) > 0)
                    low = mid + 1;
                else
                {
                    categories.AddCategory(model.name, value);
                    break;
                }
            }
        }
    }
}
