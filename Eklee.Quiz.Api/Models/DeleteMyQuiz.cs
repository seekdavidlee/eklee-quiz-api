using System.ComponentModel;

namespace Eklee.Quiz.Api.Models
{
	public class DeleteMyQuiz
	{
		[Description("Id of the Quiz.")]
		public string Id { get; set; }

		[Description("Owner of the Quiz.")]
		public string Owner { get; set; }
	}
}
