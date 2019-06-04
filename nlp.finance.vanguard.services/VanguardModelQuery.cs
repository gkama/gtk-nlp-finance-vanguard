using GraphQL.Types;

using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public class VanguardModelQuery : ObjectGraphType
    {
        public VanguardModelQuery(INlpRepository<VanguardModel> repo)
        {
            Field<VanguardModelType>(
                "vanguard_model",
                resolve: context => repo.model
                );
        }
    }
}
