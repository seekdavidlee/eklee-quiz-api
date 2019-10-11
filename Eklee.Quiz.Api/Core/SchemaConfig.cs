using GraphQL;
using GraphQL.Types;

namespace Eklee.Quiz.Api.Core
{
	public class SchemaConfig : Schema
	{
		public SchemaConfig(IDependencyResolver resolver, QueryConfigObjectGraphType query, MutationObjectGraphType mutation) : base(resolver)
		{
			Query = query;
			Mutation = mutation;
		}
	}
}
