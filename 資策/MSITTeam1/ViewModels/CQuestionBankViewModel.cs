using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
	public class CQuestionBankViewModel
	{
		private TQuestionList _question = null;
		private TQuestionDetail _choice = null;
		public CQuestionBankViewModel()
		{
			_question = new TQuestionList();
			_choice = new TQuestionDetail();
		}

		public TQuestionList question
		{
			get { return _question; }
			set { _question = value; }
		}

		public TQuestionDetail choice
		{
			get { return _choice; }
			set { _choice = value; }
		}

		[DisplayName("課程名稱")]
		public string Vsubject
		{
			get { return this.question.FSubjectId; }
			set { this.question.FSubjectId = value; }
		}

		[DisplayName("題目編號")]
		public int VquestionId 
		{ 
			get { return this.question.FQuestionId; }
			set { this.question.FQuestionId = value; } 
		}
		[DisplayName("題目")]
		public string Vquestion
		{
			get { return this.question.FQuestion; }
			set { this.question.FQuestion = value; }
		}

		[DisplayName("選項")]
		public string Vchoice
		{
			get { return this.choice.FChoice; }
			set { this.choice.FChoice = value; }
		}

		[DisplayName("難度")]
		public int Vlevel
		{
			get { return this.question.FLevel; }
			set { this.question.FLevel = value; }
		}
		[DisplayName("更新時間")]

		public string VupdateTime { get; set; }
		public int VcorrectAnswer
		{
			get { return this.choice.FCorrectAnswer; }
			set { this.choice.FCorrectAnswer = value; }
		}
		[DisplayName("題目類型")]

		public int VquestionType
		{
			get { return this.question.FQuestionTypeId; }
			set { this.question.FQuestionTypeId = value; }
		}
	}
}
