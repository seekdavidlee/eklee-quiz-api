using System.ComponentModel;

namespace Eklee.Quiz.Api.Models
{
	public class DeleteMyQuestion
	{
		[Description("Id of the Question.")]
		public string Id { get; set; }

		[Description("Owner of the Question.")]
		public string Owner { get; set; }
	}
}
