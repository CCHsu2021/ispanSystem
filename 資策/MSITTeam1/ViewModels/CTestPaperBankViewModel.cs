using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
	public class CTestPaperBankViewModel
	{
		private TTestPaperBank _testpaperbank = null;
		private TTestPaper _testpaper = null;

		public CTestPaperBankViewModel()
		{
			_testpaperbank = new TTestPaperBank();
			_testpaper = new TTestPaper();
		}
		public TTestPaperBank paperBank
		{
			get { return _testpaperbank; }
			set { _testpaperbank = value; }
		}
		public TTestPaper testPaper
		{
			get { return _testpaper; }
			set { _testpaper = value; }
		}

		public int FBTestPaperId
		{
			get { return this.paperBank.FTestPaperId; }
			set { this.paperBank.FTestPaperId = value; }
		}
		[DisplayName("創建者")]
		public string FDesignerAccount
		{
			get { return this.paperBank.FDesignerAccount; }
			set { this.paperBank.FDesignerAccount = value; }
		}
		[DisplayName("試卷名稱")]
		public string FTestPaperName
		{
			get { return this.paperBank.FTestPaperName; }
			set { this.paperBank.FTestPaperName = value; }
		}
		[DisplayName("技能名稱")]
		public string FBSubjectId
		{
			get { return this.paperBank.FSubjectId; }
			set { this.paperBank.FSubjectId = value; }
		}
		[DisplayName("試卷說明")]
		public string FNote
		{
			get { return this.paperBank.FNote; }
			set { this.paperBank.FNote = value; }
		}

		public int FSN
		{
			get { return this.testPaper.FSn; }
			set { this.testPaper.FSn = value; }
		}
		public int FTestPaperId
		{
			get { return this.testPaper.FTestPaperId; }
			set { this.testPaper.FTestPaperId = value; }
		}
		public string FSubjectId
		{
			get { return this.testPaper.FSubjectId; }
			set { this.testPaper.FSubjectId = value; }
		}
		public int FQuestionId
		{
			get { return this.testPaper.FQuestionId; }
			set { this.testPaper.FQuestionId = value; }
		}

		public List<TestPaperDetailViewModel> SelectQuestionList
		{
			get;set;
		}
	}

	public class TestPaperDetailViewModel
	{
		public int FSN { get; set; }
		public string FSubjectId { get; set; }
		public string FQuestionId { get; set; }
	}
}
