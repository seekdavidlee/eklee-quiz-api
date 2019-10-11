using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Eklee.Azure.Functions.GraphQl;
using Eklee.Quiz.Api.Models;

namespace Eklee.Quiz.Api.Core
{
	public class ReadOnlyMutationObjectGraphType : ObjectGraphType
	{
		public ReadOnlyMutationObjectGraphType(InputBuilderFactory inputBuilderFactory, IConfiguration configuration)
		{
			Name = "mutation";

			inputBuilderFactory.Create<MyQuiz>(this)
				.DisableBatchCreate()
				.DisableBatchCreateOrUpdate()
				.DisableCreate()
				.DisableCreateOrUpdate()
				.DisableDelete()
				.DisableUpdate()
				.ConfigureTableStorage<MyQuiz>()
				.AddConnectionString(configuration["Connection"])
				.AddPrefix(configuration["Prefix"])
				.AddPartition(x => x.Owner)
				.BuildTableStorage()

				.Build();

			inputBuilderFactory.Create<Question>(this)
				.DisableBatchCreate()
				.DisableBatchCreateOrUpdate()
				.DisableCreate()
				.DisableCreateOrUpdate()
				.DisableDelete()
				.DisableUpdate()
				.ConfigureTableStorage<Question>()
				.AddConnectionString(configuration["Connection"])
				.AddPrefix(configuration["Prefix"])
				.AddPartition(x => x.QuizId)
				.BuildTableStorage()
				.Build();
		}
	}
}
