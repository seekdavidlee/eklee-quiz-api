using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Eklee.Azure.Functions.GraphQl;
using Eklee.Quiz.Api.Models;

namespace Eklee.Quiz.Api.Core
{
	public class MutationObjectGraphType : ObjectGraphType
	{
		public MutationObjectGraphType(InputBuilderFactory inputBuilderFactory, IConfiguration configuration)
		{
			Name = "mutation";

			inputBuilderFactory.Create<MyQuiz>(this)
				.ConfigureTableStorage<MyQuiz>()
				.AddConnectionString(configuration["Connection"])
				.AddPrefix(configuration["Prefix"])
				.AddPartition(x => x.Owner)
				.BuildTableStorage()
				.Delete<DeleteMyQuiz, Status>(x => new MyQuiz { Id = x.Id, Owner = x.Owner }, x => new Status { Message = "Quiz has been removed." })
				.Build();

			inputBuilderFactory.Create<Question>(this)
				.ConfigureTableStorage<Question>()
				.AddConnectionString(configuration["Connection"])
				.AddPrefix(configuration["Prefix"])
				.AddPartition(x => x.QuizId)
				.BuildTableStorage()
				.Delete<DeleteMyQuestion, Status>(x => new Question { Id = x.Id, Owner = x.Owner, QuizId = x.QuizId }, x => new Status { Message = "Question has been removed." })
				.Build();
		}
	}
}
