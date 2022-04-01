using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
	public class CQueChoicesViewModel
	{
		private TQuestionDetail _choice = null;
		public TQuestionDetail choice
		{
			get { return _choice; }
			set { _choice = value; }
		}

		[DisplayName("選項")]
		public string Vchoice
		{
			get { return this.choice.FChoice; }
			set { this.choice.FChoice = value; }
		}

		public int VcorrectAnswer
		{
			get { return this.choice.FCorrectAnswer; }
			set { this.choice.FCorrectAnswer = value; }
		}
	}
}
