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

        public IEnumerable<IEnumerable<string>> Categorize(string content)
        {
            /*
             * 1) generate the stack of models to iterate through
             * 2) tokenize the content
             */
            var models = new Stack<T>(model.children);
            var toReturn = new List<IEnumerable<string>>();

            while (models.Any())
            {
                var m = models.Pop() as IModel<T>;

                content.Split(' ').ToList().ForEach(x =>
                {
                    toReturn.Add(BinarySearchDetails(x, m));
                });

                if (m.children.Any())
                    m.children.ToList().ForEach(x =>
                    {
                        models.Push(x);
                    });
            }

            return toReturn;
        }

        private IEnumerable<string> BinarySearchDetails(string value, IModel<T> model)
        {
            var low = 0;
            var high = model.details_split.Count() - 1;
            var mid = 0;
            var details_array = model.details_split as string[];
            var matched_words = new List<string>();

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (string.Compare(value, details_array[mid], true) < 0)
                    high = mid - 1;
                else if (string.Compare(value, details_array[mid], true) > 0)
                    low = mid + 1;
                else
                {
                    if (!matched_words.Contains(value))
                    {
                        matched_words.Add(value);
                        break;
                    }
                    else
                        break;
                }
            }

            return matched_words;
        }
    }
}
