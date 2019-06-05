using GraphQL.Types;

using nlp.finance.vanguard.data;

namespace nlp.finance.vanguard.services
{
    public class NlpQuery : ObjectGraphType
    {
        public NlpQuery(INlpRepository<VanguardModel> repo)
        {
            Field<VanguardModelType>(
                "vanguard_model",
                resolve: context => repo.model
                );

            Field<ListGraphType<CategoryType>>(
                "categorize",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "content" }
                    ),
                resolve: context =>
                {
                    var content = context.GetArgument<string>("content");

                    return repo.Categorize(content);
                });
        }
    }
}
