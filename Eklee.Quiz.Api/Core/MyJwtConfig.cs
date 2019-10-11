using Eklee.Azure.Functions.Http;
using Microsoft.Extensions.Configuration;

namespace Eklee.Quiz.Api.Core
{
	public class MyJwtConfig : IJwtTokenValidatorParameters
	{
		public MyJwtConfig(IConfiguration configuration)
		{
			Audience = configuration["Security:Audience"];

			Issuers = configuration["Security:Issuers"].Split(' ');
		}

		/// <summary>
		/// Represents the Quiz API application.
		/// </summary>
		public string Audience { get; }

		/// <summary>
		/// This represents the federated AAD instances which represents our customers' identity providers.
		/// </summary>
		public string[] Issuers { get; }
	}
}
