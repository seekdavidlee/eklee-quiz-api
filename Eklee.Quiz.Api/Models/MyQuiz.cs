using Eklee.Azure.Functions.GraphQl.Attributes;
using Eklee.Quiz.Api.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eklee.Quiz.Api.Models
{
	public class MyQuiz
	{
		[AutoId]
		[Key]
		[Description("Id of the Quiz.")]
		public string Id { get; set; }

		[Description("Name of the Quiz.")]
		public string Name { get; set; }

		[ModelField(false)]
		[RequestContextValue(typeof(ValueFromEmail))]
		[Description("Name of the Quiz.")]
		public string Owner { get; set; }

		[Description("Determines if this is public.")]
		public bool IsPublic { get; set; }
	}
}
