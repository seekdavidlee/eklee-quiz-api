using Eklee.Azure.Functions.GraphQl;
using Eklee.Azure.Functions.GraphQl.Actions.RequestContextValueExtractors;
using FastMember;
using System;
using System.Threading.Tasks;

namespace Eklee.Quiz.Api.Core
{
	public class ValueFromEmail : IRequestContextValueExtractor
	{
		public Task<object> GetValueAsync(IGraphRequestContext graphRequestContext, Member member)
		{
			if (graphRequestContext.HttpRequest.Security != null)
			{
				return Task.FromResult(
					(object)graphRequestContext.HttpRequest.Security.ClaimsPrincipal.GetEmail());
			}
			throw new NotImplementedException();
		}
	}
}
