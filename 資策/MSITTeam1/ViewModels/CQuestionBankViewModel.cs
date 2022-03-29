using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
	public class CQuestionBankViewModel
	{
		[DisplayName("課程名稱")]
		public string subject { get; set; }

		[DisplayName("題目編號")]
		public int questionId { get; set; }
		[DisplayName("題目")]
		public string question { get; set; }

		[DisplayName("選項")]
		public string choice { get; set; }

		[DisplayName("難度")]
		public int level { get; set; }
		[DisplayName("更新時間")]

		public string updateTime { get; set; }
		public int correctAnswer { get; set; }
		[DisplayName("題目類型")]

		public string questionType { get; set; }
	}
}
