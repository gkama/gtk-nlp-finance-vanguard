using GraphQL.Types;

namespace nlp.finance.vanguard.data
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.name);
            Field(x => x.total_weight);

            Field<ListGraphType<MatchedType>>("matched", resolve: context => context.Source.matched);
        }
    }

    public class MatchedType : ObjectGraphType<Matched>
    {
        public MatchedType()
        {
            Field(x => x.value);
            Field(x => x.weight);
        }
    }
}
