using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eklee.Quiz.Api.Models
{
	public class MyReadOnlyQuiz
	{
		[Key]
		[Description("Id of the Quiz.")]
		public string Id { get; set; }

		[Description("Name of the Quiz.")]
		public string Name { get; set; }

		[Description("Questions.")]
		public List<MyReadOnlyQuestion> Questions { get; set; }
	}
}
