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
		public string Vsubject { get; set; }

		[DisplayName("題目編號")]
		public int VquestionId { get; set; }
		[DisplayName("題目")]
		public string Vquestion { get; set; }

		[DisplayName("選項")]
		public string Vchoice { get; set; }

		[DisplayName("難度")]
		public int Vlevel { get; set; }
		[DisplayName("更新時間")]

		public string VupdateTime { get; set; }
		public int VcorrectAnswer { get; set; }
		[DisplayName("題目類型")]

		public string VquestionType { get; set; }
	}
}
