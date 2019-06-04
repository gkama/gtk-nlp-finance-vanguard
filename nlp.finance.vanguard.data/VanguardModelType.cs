using GraphQL.Types;

namespace nlp.finance.vanguard.data
{
    public class VanguardModelType : ObjectGraphType<VanguardModel>
    {
        public VanguardModelType()
        {
            Field(x => x.id);
            Field(x => x.name);
            Field(x => x.details);

            Field<ListGraphType<VanguardModelType>>("children", resolve: context => context.Source.children);
        }
    }
}
