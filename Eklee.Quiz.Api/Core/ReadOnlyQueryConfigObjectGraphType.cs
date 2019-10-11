using GraphQL.Types;
using Eklee.Azure.Functions.GraphQl;
using Eklee.Quiz.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Eklee.Quiz.Api.Core
{
	public class ReadOnlyQueryConfigObjectGraphType : ObjectGraphType<object>
	{
		public ReadOnlyQueryConfigObjectGraphType(QueryBuilderFactory queryBuilderFactory)
		{
			Name = "query";

			queryBuilderFactory.Create<MyReadOnlyQuiz>(this, "GetQuiz")
				.WithParameterBuilder()
				.BeginQuery<MyQuiz>()
				.WithProperty(x => x.Id)
				.WithPropertyFromSource(x => x.IsPublic, ctx => new List<object> { true })
				.BuildQueryResult(ctx =>
				{
					var list = ctx.GetQueryResults<MyQuiz>();

					if (list != null)
					{
						var item = list.SingleOrDefault();
						if (item != null)
						{
							var readonlyQuiz = new MyReadOnlyQuiz();
							readonlyQuiz.Id = item.Id;
							readonlyQuiz.Name = item.Name;
							ctx.Items["QuizId"] = new List<object> { list.Single().Id };
							ctx.SetResults(new List<MyReadOnlyQuiz> { readonlyQuiz });

							return;
						}
					}

					ctx.Items["QuizId"] = new List<object>();
					ctx.SetResults(new List<MyReadOnlyQuiz>());
				})
				.ThenWithQuery<Question>()
				.WithPropertyFromSource(x => x.QuizId, ctx => (List<object>)ctx.Items["QuizId"])
				.BuildQueryResult(ctx =>
				{
					var items = ctx.GetResults<MyReadOnlyQuiz>();
					if (items != null)
					{
						var item = items.SingleOrDefault();
						if (item != null)
						{
							item.Questions = ctx.GetQueryResults<Question>().Select(x => new MyReadOnlyQuestion
							{
								Id = x.Id,
								Text = x.Text,
								ChoicesJson = x.ChoicesJson,
								ExplainJson = x.ExplainJson,
								TagsJson = x.TagsJson
							}).ToList();
						}
					}
				})
				.BuildQuery()
				.BuildWithSingleResult();
		}
	}
}
