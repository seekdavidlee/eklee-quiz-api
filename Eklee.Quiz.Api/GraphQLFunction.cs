using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Eklee.Quiz.Api.Core;
using Eklee.Azure.Functions.Http;
using Eklee.Azure.Functions.GraphQl;

namespace Eklee.Quiz.Api
{
	public static class GraphQLFunction
	{
		[ExecutionContextDependencyInjection(typeof(FunctionModule))]
		[FunctionName("graph")]
		public static async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graph")] HttpRequest req,
			ILogger log,
			ExecutionContext executionContext)
		{
			log.LogInformation("Executing graph");
			return await executionContext.ProcessGraphQlRequest(req);
		}

		[ExecutionContextDependencyInjection(typeof(ReadOnlyFunctionModule))]
		[FunctionName("readonly-graph")]
		public static async Task<IActionResult> RunReadOnly(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "readonly-graph")] HttpRequest req,
			ILogger log, ExecutionContext executionContext)
		{
			log.LogInformation("Executing readonly-graph");
			return await executionContext.ProcessGraphQlRequest(req);
		}
	}
}
