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
        public ICollection<ICategory> categories { get; set; } = new List<ICategory>();
        public ILogger log { get; }

        public NlpRepository(IModel<T> model, ILogger<NlpRepository<T>> log)
        {
            this.model = model;
            this.log = log;
        }

        public IEnumerable<ICategory> Categorize(string content)
        {
            var models = new Stack<T>(model.children);

            var sw = new Stopwatch();

            sw.Start();
            while (models.Any())
            {
                var m = models.Pop() as IModel<T>;

                content.Tokenize().ForEach(x =>
                {
                    BinarySearchDetails(x, m);
                });

                //categorization of phrases
                //grab all details that contain spaces and add it to the categories
                m.details_split
                    .Where(x => x.Contains(' '))
                    .ToList()
                    .ForEach(x =>
                    {
                        if (content.Contains(x))
                            categories.AddCategory(m.name, x);
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

        private void BinarySearchDetails(string value, IModel<T> model)
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
