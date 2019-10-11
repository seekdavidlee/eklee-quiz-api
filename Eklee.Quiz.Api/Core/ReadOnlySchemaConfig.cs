using GraphQL;
using GraphQL.Types;

namespace Eklee.Quiz.Api.Core
{
	public class ReadOnlySchemaConfig : Schema
	{
		public ReadOnlySchemaConfig(IDependencyResolver resolver, ReadOnlyQueryConfigObjectGraphType query, ReadOnlyMutationObjectGraphType mutation) : base(resolver)
		{
			Query = query;
			Mutation = mutation;
		}
	}
}
