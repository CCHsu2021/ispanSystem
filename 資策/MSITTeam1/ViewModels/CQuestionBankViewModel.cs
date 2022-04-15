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

		public int FSn
		{
			get { return this.choice.FSn; }
			set { this.choice.FSn = value; }
		}

		[DisplayName("課程名稱")]
		public string FSubjectId
		{
			get { return this.question.FSubjectId; }
			set { this.question.FSubjectId = value; }
		}

		public string FCSubjectId
		{
			get { return this.choice.FSubjectId; }
			set { this.choice.FSubjectId = value; }
		}

		[DisplayName("題目編號")]
		public int FQuestionId
		{ 
			get { return this.question.FQuestionId; }
			set { this.question.FQuestionId = value; } 
		}

		public int FCQuestionId
		{
			get { return this.choice.FQuestionId; }
			set { this.choice.FQuestionId = value; }
		}

		[DisplayName("題目")]
		public string FQuestion
		{
			get { return this.question.FQuestion; }
			set { this.question.FQuestion = value; }
		}

		[DisplayName("選項")]
		public string FChoice
		{
			get { return this.choice.FChoice; }
			set { this.choice.FChoice = value; }
		}

		[DisplayName("難度")]
		public int FLevel
		{
			get { return this.question.FLevel; }
			set { this.question.FLevel = value; }
		}
		[DisplayName("更新時間")]

		public string VupdateTime { get; set; }
		public int FCorrectAnswer
		{
			get { return this.choice.FCorrectAnswer; }
			set { this.choice.FCorrectAnswer = value; }
		}
		[DisplayName("題目類型")]

		public int FQuestionTypeId
		{
			get { return this.question.FQuestionTypeId; }
			set { this.question.FQuestionTypeId = value; }
		}

		public string FSubmitterId
		{
			get { return this.question.FSubmitterId; }
			set { this.question.FSubmitterId = value; }
		}

		public int FState
		{
			get { return this.question.FState; }
			set { this.question.FState = value; }
		}

		public List<string> FChoiceList
		{
			get;set;
		}

		//private TQuestionDetail test { get; set; }

		//public string VTchoice
		//{
		//	get { return this.test.FChoice; }
		//	set { this.test.FChoice = value; }
		//}

	}
}
