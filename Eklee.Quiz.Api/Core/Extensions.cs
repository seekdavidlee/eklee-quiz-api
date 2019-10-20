using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Eklee.Quiz.Api.Core
{
	public static class Extensions
	{
		private const string EMAIL_ADDRESS = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
		private const string UPN = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn";

		public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
		{
			var emailClaim = claimsPrincipal.FindFirst(x => x.Type == EMAIL_ADDRESS);
			if (emailClaim != null)
			{
				return emailClaim.Value;
			}

			emailClaim = claimsPrincipal.FindFirst(x => x.Type == UPN);
			if (emailClaim != null)
			{
				return emailClaim.Value;
			}

			throw new NotImplementedException();
		}
	}
}
