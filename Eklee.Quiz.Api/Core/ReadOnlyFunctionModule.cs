using Autofac;
using Eklee.Azure.Functions.GraphQl;
using Eklee.Azure.Functions.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace Eklee.Quiz.Api.Core
{
	public class ReadOnlyFunctionModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.UseDistributedCache<MemoryDistributedCache>();

			builder.RegisterGraphQl<ReadOnlySchemaConfig>();
			builder.RegisterType<ReadOnlyQueryConfigObjectGraphType>();
			builder.RegisterType<ReadOnlyMutationObjectGraphType>();
		}
	}
}
