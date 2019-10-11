using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eklee.Quiz.Api.Models
{
	public class MyReadOnlyQuestion
	{
		[Key]
		[Description("Id of the Question.")]
		public string Id { get; set; }

		[Description("The question to ask.")]
		public string Text { get; set; }

		[Description("JSON Choices.")]
		public string ChoicesJson { get; set; }

		[Description("JSON Explaination.")]
		public string ExplainJson { get; set; }

		[Description("JSON Tags.")]
		public string TagsJson { get; set; }
	}
}
