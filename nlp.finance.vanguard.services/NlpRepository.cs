using System;

using Microsoft.Extensions.Logging;

using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public class NlpRepository : INlpRepository
    {
        public VanguardModel vanguard_model { get; }

        public readonly ILogger log;

        public NlpRepository(VanguardModel vanguard_model, ILogger<NlpRepository> log)
        {
            this.vanguard_model = vanguard_model;
            this.log = log;
        }
    }
}
