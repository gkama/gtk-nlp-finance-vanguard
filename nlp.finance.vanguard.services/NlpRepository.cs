using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Logging;

using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public class NlpRepository : INlpRepository
    {
        public IModel<VanguardModel> vanguard_model { get; }
        public ILogger log { get; }

        public NlpRepository(IModel<VanguardModel> vanguard_model, ILogger<NlpRepository> log)
        {
            this.vanguard_model = vanguard_model;
            this.log = log;
        }

        private IEnumerable<string> BinarySearchDetails(string value)
        {
            var low = 0;
            var high = vanguard_model.details_split.Count() - 1;
            var mid = 0;
            var details_array = vanguard_model.details_split as string[];
            var matched_words = new List<string>();

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (string.Compare(value, details_array[mid], true) < 0)
                    high = mid - 1;
                else if (string.Compare(value, details_array[mid], true) > 0)
                    low = mid + 1;
                else
                    matched_words.Add(details_array[mid]);
            }

            return matched_words;
        }
    }
}
