using GraphQL;
using GraphQL.Types;

namespace nlp.finance.vanguard.services
{
    public class VanguardModelSchema : Schema
    {
        public VanguardModelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<VanguardModelQuery>();
        }
    }
}
