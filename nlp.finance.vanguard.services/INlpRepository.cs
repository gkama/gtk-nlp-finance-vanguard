using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public interface INlpRepository<T>
        where T : class
    {
        IModel<T> model { get; }
    }
}
