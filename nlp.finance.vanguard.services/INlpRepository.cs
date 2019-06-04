using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public interface INlpRepository
    {
        IModel<VanguardModel> vanguard_model { get; }
    }
}
