using Eklee.Azure.Functions.GraphQl.Attributes;
using Eklee.Quiz.Api.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eklee.Quiz.Api.Models
{
	public class Question
	{
		[AutoId]
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

		[ModelField(false)]
		[RequestContextValue(typeof(ValueFromEmail))]
		[Description("Owner of the question.")]
		public string Owner { get; set; }

		[Description("Quiz Id.")]
		public string QuizId { get; set; }
	}
}
