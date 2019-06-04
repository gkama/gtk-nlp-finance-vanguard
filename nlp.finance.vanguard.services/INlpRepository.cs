using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public interface INlpRepository
    {
        VanguardModel vanguard_model { get; }
    }
}
