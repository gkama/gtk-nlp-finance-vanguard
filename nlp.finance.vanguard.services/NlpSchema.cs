using GraphQL;
using GraphQL.Types;

namespace nlp.finance.vanguard.services
{
    public class NlpSchema : Schema
    {
        public NlpSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<NlpQuery>();
        }
    }
}
