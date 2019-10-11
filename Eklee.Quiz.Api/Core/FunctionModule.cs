using Autofac;
using Eklee.Azure.Functions.GraphQl;
using Eklee.Azure.Functions.GraphQl.Actions.RequestContextValueExtractors;
using Eklee.Azure.Functions.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace Eklee.Quiz.Api.Core
{
	public class FunctionModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.UseDistributedCache<MemoryDistributedCache>();
			builder.UseJwtAuthorization<MyJwtConfig>();

			builder.UseSystemModelTransformers();
			builder.UseValueFromRequestContextGenerator();
			builder.RegisterType<ValueFromEmail>().As<IRequestContextValueExtractor>().SingleInstance();

			builder.RegisterGraphQl<SchemaConfig>();
			builder.RegisterType<QueryConfigObjectGraphType>();
			builder.RegisterType<MutationObjectGraphType>();
		}
	}
}
