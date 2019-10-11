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
				var emailClaim = graphRequestContext.HttpRequest.Security.ClaimsPrincipal.FindFirst(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
				if (emailClaim != null)
				{
					return Task.FromResult((object)emailClaim.Value);
				}
			}
			throw new NotImplementedException();
		}
	}
}
