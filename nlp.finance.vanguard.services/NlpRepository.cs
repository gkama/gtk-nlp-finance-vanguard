using System;

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
    }
}
