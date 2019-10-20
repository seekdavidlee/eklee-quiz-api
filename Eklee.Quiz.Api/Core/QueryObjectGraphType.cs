using GraphQL.Types;
using Eklee.Azure.Functions.GraphQl;
using Eklee.Quiz.Api.Models;
using System;
using System.Collections.Generic;

namespace Eklee.Quiz.Api.Core
{
	public class QueryConfigObjectGraphType : ObjectGraphType<object>
	{
		private const string EMAIL_ADDRESS = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
		private const string UPN = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn";

		private List<object> GetEmail(QueryExecutionContext queryExecutionContext)
		{
			var graphRequestContext = queryExecutionContext.RequestContext;
			if (graphRequestContext.HttpRequest.Security != null)
			{
				return new List<object> { graphRequestContext.HttpRequest.Security.ClaimsPrincipal.GetEmail() };
			}
			throw new NotImplementedException();
		}

		public QueryConfigObjectGraphType(QueryBuilderFactory queryBuilderFactory)
		{
			Name = "query";

			queryBuilderFactory.Create<MyQuiz>(this, "GetAllMyQuizes")
				.WithParameterBuilder()
				.BeginQuery<MyQuiz>()
				.WithPropertyFromSource(x => x.Owner, ctx => GetEmail(ctx))
				.BuildQueryResult(ctx =>
				{
					ctx.SetResults(ctx.GetQueryResults<MyQuiz>());
				})
				.BuildQuery()
				.BuildWithListResult();

			queryBuilderFactory.Create<Question>(this, "GetMyQuestions")
				.WithParameterBuilder()
				.BeginQuery<Question>()
				.WithProperty(x => x.QuizId)
				.WithPropertyFromSource(x => x.Owner, ctx => GetEmail(ctx))
				.BuildQueryResult(ctx =>
				{
					ctx.SetResults(ctx.GetQueryResults<Question>());
				})
				.BuildQuery()
				.BuildWithListResult();
		}
	}
}
