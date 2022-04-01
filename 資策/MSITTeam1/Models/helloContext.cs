using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class helloContext : DbContext
    {
        public helloContext()
        {
        }

        public helloContext(DbContextOptions<helloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentBasic> StudentBasics { get; set; }
        public virtual DbSet<StudentEducation> StudentEducations { get; set; }
        public virtual DbSet<StudentLanguage> StudentLanguages { get; set; }
        public virtual DbSet<StudentPortfolio> StudentPortfolios { get; set; }
        public virtual DbSet<StudentReflection> StudentReflections { get; set; }
        public virtual DbSet<StudentResume> StudentResumes { get; set; }
        public virtual DbSet<StudentSchool> StudentSchools { get; set; }
        public virtual DbSet<StudentSkill> StudentSkills { get; set; }
        public virtual DbSet<StudentWorkExperience> StudentWorkExperiences { get; set; }
        public virtual DbSet<TAdministrator> TAdministrators { get; set; }
        public virtual DbSet<TBonusDefination> TBonusDefinations { get; set; }
        public virtual DbSet<TCityContrast> TCityContrasts { get; set; }
        public virtual DbSet<TClassGrade> TClassGrades { get; set; }
        public virtual DbSet<TClassInfo> TClassInfos { get; set; }
        public virtual DbSet<TClassOrder> TClassOrders { get; set; }
        public virtual DbSet<TClassOrderDetail> TClassOrderDetails { get; set; }
        public virtual DbSet<TClassTestPaper> TClassTestPapers { get; set; }
        public virtual DbSet<TCompanyAppendix> TCompanyAppendices { get; set; }
        public virtual DbSet<TCompanyBasic> TCompanyBasics { get; set; }
        public virtual DbSet<TCompanyPoint> TCompanyPoints { get; set; }
        public virtual DbSet<TCompanyRespond> TCompanyResponds { get; set; }
        public virtual DbSet<TCompanyRespondTemp> TCompanyRespondTemps { get; set; }
        public virtual DbSet<TJobDirect> TJobDirects { get; set; }
        public virtual DbSet<TJobVacancy> TJobVacancies { get; set; }
        public virtual DbSet<TLanguageForm> TLanguageForms { get; set; }
        public virtual DbSet<TMember> TMembers { get; set; }
        public virtual DbSet<TMemberCoverLetterTemp> TMemberCoverLetterTemps { get; set; }
        public virtual DbSet<TMemberLevel> TMemberLevels { get; set; }
        public virtual DbSet<TMemberLevelRecord> TMemberLevelRecords { get; set; }
        public virtual DbSet<TMemberResumeSend> TMemberResumeSends { get; set; }
        public virtual DbSet<TPhoto> TPhotos { get; set; }
        public virtual DbSet<TProduct> TProducts { get; set; }
        public virtual DbSet<TProductOrder> TProductOrders { get; set; }
        public virtual DbSet<TProductOrderDetail> TProductOrderDetails { get; set; }
        public virtual DbSet<TQuestionDetail> TQuestionDetails { get; set; }
        public virtual DbSet<TQuestionList> TQuestionLists { get; set; }
        public virtual DbSet<TReceipt> TReceipts { get; set; }
        public virtual DbSet<TRelation> TRelations { get; set; }
        public virtual DbSet<TResultDescription> TResultDescriptions { get; set; }
        public virtual DbSet<TSkill> TSkills { get; set; }
        public virtual DbSet<TSkillGrade> TSkillGrades { get; set; }
        public virtual DbSet<TSkillTestPaper> TSkillTestPapers { get; set; }
        public virtual DbSet<TStudentPoint> TStudentPoints { get; set; }
        public virtual DbSet<TStudioInformation> TStudioInformations { get; set; }
        public virtual DbSet<TSubmittedAnswer> TSubmittedAnswers { get; set; }
        public virtual DbSet<TTestPaper> TTestPapers { get; set; }
        public virtual DbSet<TTestPaperBank> TTestPaperBanks { get; set; }
        public virtual DbSet<TTestResult> TTestResults { get; set; }
        public virtual DbSet<VGetDate> VGetDates { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=tcp:msit40team1.database.windows.net,1433;Initial Catalog=hello;User ID=MSIT40;Password=Ispan40team1");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<StudentBasic>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_StudentBasic_1");

                entity.ToTable("StudentBasic");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberID")
                    .HasDefaultValueSql("([dbo].[MemberIDnum]())");

                entity.Property(e => e.Autobiography).HasDefaultValueSql("('未填寫')");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('未填寫')");

                entity.Property(e => e.ContactAddress)
                    .HasMaxLength(80)
                    .HasDefaultValueSql("('未填寫')");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('未填寫')");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FCheckStatus)
                    .HasMaxLength(10)
                    .HasColumnName("fCheckStatus")
                    .IsFixedLength(true);

                entity.Property(e => e.FCity)
                    .HasMaxLength(50)
                    .HasColumnName("fCity");

                entity.Property(e => e.FClassMessage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fClassMessage");

                entity.Property(e => e.FCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fCompany");

                entity.Property(e => e.FDateTime)
                    .HasMaxLength(50)
                    .HasColumnName("fDateTime");

                entity.Property(e => e.FDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("fDistrict");

                entity.Property(e => e.FGuid).HasColumnName("fGuid");

                entity.Property(e => e.FMemberType).HasColumnName("fMemberType");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(48)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FSalt)
                    .HasMaxLength(20)
                    .HasColumnName("fSalt");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('未填寫')");

                entity.Property(e => e.Member).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('未填寫')")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('未填寫')");

                entity.Property(e => e.Portrait).HasDefaultValueSql("('未上傳')");
            });

            modelBuilder.Entity<StudentEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId);

                entity.ToTable("StudentEducation");

                entity.Property(e => e.EducationId).HasColumnName("EducationID");

                entity.Property(e => e.GraduateDepartment).HasMaxLength(50);

                entity.Property(e => e.GraduateSchool).HasMaxLength(50);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudyFrom).HasMaxLength(50);

                entity.Property(e => e.StudyTo).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentLanguage>(entity =>
            {
                entity.HasKey(e => e.LanguageId)
                    .HasName("PK_Language");

                entity.ToTable("StudentLanguage");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LanguageName).HasMaxLength(10);

                entity.Property(e => e.Listening).HasMaxLength(10);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reading).HasMaxLength(10);

                entity.Property(e => e.Speaking).HasMaxLength(10);

                entity.Property(e => e.Writing).HasMaxLength(10);
            });

            modelBuilder.Entity<StudentPortfolio>(entity =>
            {
                entity.HasKey(e => e.PortfolioId);

                entity.ToTable("StudentPortfolio");

                entity.Property(e => e.PortfolioId).HasColumnName("PortfolioID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PortfolioTitle).HasMaxLength(50);

                entity.Property(e => e.PortfolioUrl)
                    .IsUnicode(false)
                    .HasColumnName("PortfolioURL");
            });

            modelBuilder.Entity<StudentReflection>(entity =>
            {
                entity.HasKey(e => e.ReflectionId);

                entity.ToTable("StudentReflection");

                entity.Property(e => e.ReflectionId).HasColumnName("ReflectionID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReflectionTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentResume>(entity =>
            {
                entity.HasKey(e => e.ResumeId);

                entity.ToTable("StudentResume");

                entity.Property(e => e.ResumeId).HasColumnName("ResumeID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RBasic).HasColumnName("rBasic");

                entity.Property(e => e.REducation).HasColumnName("rEducation");

                entity.Property(e => e.RLanguage).HasColumnName("rLanguage");

                entity.Property(e => e.RPortfolio).HasColumnName("rPortfolio");

                entity.Property(e => e.RSkill).HasColumnName("rSkill");

                entity.Property(e => e.RWorkExp).HasColumnName("rWorkExp");
            });

            modelBuilder.Entity<StudentSchool>(entity =>
            {
                entity.HasKey(e => e.SchooolId);

                entity.ToTable("StudentSchool");

                entity.Property(e => e.SchooolId).HasColumnName("schooolId");

                entity.Property(e => e.SchoolName).HasColumnName("schoolName");
            });

            modelBuilder.Entity<StudentSkill>(entity =>
            {
                entity.HasKey(e => e.SkillId)
                    .HasName("PK_Skill");

                entity.ToTable("StudentSkill");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SkillName).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentWorkExperience>(entity =>
            {
                entity.HasKey(e => e.WorkExperienceId);

                entity.ToTable("StudentWorkExperience");

                entity.Property(e => e.WorkExperienceId).HasColumnName("WorkExperienceID");

                entity.Property(e => e.CompanyDepartment).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.EmploymentFrom).HasMaxLength(50);

                entity.Property(e => e.EmploymentTo).HasMaxLength(50);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TAdministrator>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK_administrator");

                entity.ToTable("tAdministrator");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(50)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fPassword");
            });

            modelBuilder.Entity<TBonusDefination>(entity =>
            {
                entity.HasKey(e => e.DefinationId)
                    .HasName("PK_tBonusDefination_1");

                entity.ToTable("tBonusDefination");

                entity.Property(e => e.DefinationId).HasColumnName("DefinationID");

                entity.Property(e => e.BonusTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TCityContrast>(entity =>
            {
                entity.HasKey(e => new { e.FCityName, e.FDistrictName });

                entity.ToTable("tCityContrast");

                entity.Property(e => e.FCityName)
                    .HasMaxLength(50)
                    .HasColumnName("fCityName");

                entity.Property(e => e.FDistrictName)
                    .HasMaxLength(50)
                    .HasColumnName("fDistrictName");

                entity.Property(e => e.FPostCode).HasColumnName("fPostCode");
            });

            modelBuilder.Entity<TClassGrade>(entity =>
            {
                entity.HasKey(e => e.FAccountId);

                entity.ToTable("tClassGrade");

                entity.Property(e => e.FAccountId)
                    .HasMaxLength(50)
                    .HasColumnName("fAccountID");

                entity.Property(e => e.FAfterClassGrade).HasColumnName("fAfterClassGrade");

                entity.Property(e => e.FAfterClassTime)
                    .HasColumnType("date")
                    .HasColumnName("fAfterClassTime");

                entity.Property(e => e.FBeforeClassGrade).HasColumnName("fBeforeClassGrade");

                entity.Property(e => e.FBeforeClassTime)
                    .HasColumnType("date")
                    .HasColumnName("fBeforeClassTime");

                entity.Property(e => e.FClassCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fClassCode");
            });

            modelBuilder.Entity<TClassInfo>(entity =>
            {
                entity.HasKey(e => e.FAccount);

                entity.ToTable("tClassInfo");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(50)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FClassname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fClassname");

                entity.Property(e => e.FIdentify)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fIdentify");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FTestpaper)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fTestpaper");
            });

            modelBuilder.Entity<TClassOrder>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.OrderId })
                    .HasName("PK_tOrderInformation");

                entity.ToTable("tClassOrder");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasMaxLength(50);

                entity.Property(e => e.Date).HasMaxLength(50);

                entity.Property(e => e.Invoice).HasMaxLength(50);
            });

            modelBuilder.Entity<TClassOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ClassCode })
                    .HasName("PK_tOrderDetail");

                entity.ToTable("tClassOrderDetail");

                entity.Property(e => e.OrderId).HasMaxLength(50);

                entity.Property(e => e.ClassCode).HasMaxLength(50);
            });

            modelBuilder.Entity<TClassTestPaper>(entity =>
            {
                entity.HasKey(e => new { e.TestPaperId, e.TopicId, e.ChoseAnswer })
                    .HasName("PK_tClassTestPaper_1");

                entity.ToTable("tClassTestPaper");

                entity.Property(e => e.TestPaperId).HasColumnName("TestPaperID");

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.Property(e => e.ChoseAnswer).HasMaxLength(50);

                entity.Property(e => e.ClassMember).HasMaxLength(50);

                entity.Property(e => e.TopicAnswer).HasMaxLength(50);
            });

            modelBuilder.Entity<TCompanyAppendix>(entity =>
            {
                entity.HasKey(e => e.AppendixId);

                entity.ToTable("tCompanyAppendix");

                entity.Property(e => e.AppendixId).HasColumnName("AppendixID");

                entity.Property(e => e.AppendixContent)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AppendixName).HasMaxLength(20);

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CompanyID")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TCompanyBasic>(entity =>
            {
                entity.HasKey(e => e.CompanyTaxid)
                    .HasName("PK_tCompanyBasic_1");

                entity.ToTable("tCompanyBasic");

                entity.Property(e => e.CompanyTaxid)
                    .HasMaxLength(50)
                    .HasColumnName("CompanyTAXID");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FBenefits).HasColumnName("fBenefits");

                entity.Property(e => e.FCapitalAmount).HasColumnName("fCapitalAmount");

                entity.Property(e => e.FCity)
                    .HasMaxLength(50)
                    .HasColumnName("fCity");

                entity.Property(e => e.FContactPerson)
                    .HasMaxLength(50)
                    .HasColumnName("fContactPerson");

                entity.Property(e => e.FCustomInfo).HasColumnName("fCustomInfo");

                entity.Property(e => e.FDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("fDistrict");

                entity.Property(e => e.FDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("fDistrictCode");

                entity.Property(e => e.FDueDate)
                    .HasMaxLength(50)
                    .HasColumnName("fDueDate");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FFax).HasColumnName("fFax");

                entity.Property(e => e.FFaxCode).HasColumnName("fFaxCode");

                entity.Property(e => e.FLevel).HasColumnName("fLevel");

                entity.Property(e => e.FLogo)
                    .HasMaxLength(50)
                    .HasColumnName("fLogo");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(48)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhone).HasColumnName("fPhone");

                entity.Property(e => e.FPhoneCode).HasColumnName("fPhoneCode");

                entity.Property(e => e.FPointState).HasColumnName("fPointState");

                entity.Property(e => e.FSalt)
                    .HasMaxLength(20)
                    .HasColumnName("fSalt");
            });

            modelBuilder.Entity<TCompanyPoint>(entity =>
            {
                entity.HasKey(e => new { e.CompanyTaxid, e.PointUsageId })
                    .HasName("PK_tMemberPoint");

                entity.ToTable("tCompanyPoint");

                entity.Property(e => e.CompanyTaxid)
                    .HasMaxLength(20)
                    .HasColumnName("CompanyTAXID");

                entity.Property(e => e.PointUsageId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PointUsageID");

                entity.Property(e => e.OrderId).HasMaxLength(50);

                entity.Property(e => e.PointDate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PointDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PointType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TCompanyRespond>(entity =>
            {
                entity.HasKey(e => e.CompanyRespondId)
                    .HasName("PK_tCompany_Respond");

                entity.ToTable("tCompanyRespond");

                entity.Property(e => e.CompanyRespondId).HasColumnName("CompanyRespondID");

                entity.Property(e => e.ContactPerson).HasMaxLength(50);

                entity.Property(e => e.ContactPersonEmail).HasMaxLength(50);

                entity.Property(e => e.ContactPersonFax).HasMaxLength(50);

                entity.Property(e => e.ContactPersonPhone).HasMaxLength(50);

                entity.Property(e => e.CreatTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InterviewAddress).HasMaxLength(50);

                entity.Property(e => e.InterviewContent).HasMaxLength(500);

                entity.Property(e => e.InterviewState)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.InterviewTime).HasMaxLength(50);

                entity.Property(e => e.ModifyTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResumeSendId).HasColumnName("ResumeSendID");

                entity.Property(e => e.StudentRespondTime)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ResumeSend)
                    .WithMany(p => p.TCompanyResponds)
                    .HasForeignKey(d => d.ResumeSendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tCompanyRespond_tMemberResumeSend");
            });

            modelBuilder.Entity<TCompanyRespondTemp>(entity =>
            {
                entity.HasKey(e => e.TempId)
                    .HasName("PK_tCompany_Respond_Temp");

                entity.ToTable("tCompanyRespondTemp");

                entity.Property(e => e.TempId).HasColumnName("TempID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.TempContent).HasMaxLength(500);

                entity.Property(e => e.TempName).HasMaxLength(20);
            });

            modelBuilder.Entity<TJobDirect>(entity =>
            {
                entity.HasKey(e => e.JobListId);

                entity.ToTable("tJobDirect");

                entity.Property(e => e.JobListId)
                    .ValueGeneratedNever()
                    .HasColumnName("JobListID");

                entity.Property(e => e.FClass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fClass");

                entity.Property(e => e.FJobDirect)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fJobDirect");
            });

            modelBuilder.Entity<TJobVacancy>(entity =>
            {
                entity.HasKey(e => e.FJobId)
                    .HasName("PK_tJobVacancy_1");

                entity.ToTable("tJobVacancy");

                entity.Property(e => e.FJobId).HasColumnName("fJobID");

                entity.Property(e => e.FAccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FCity)
                    .HasMaxLength(50)
                    .HasColumnName("fCity");

                entity.Property(e => e.FCompanyId).HasColumnName("fCompanyID");

                entity.Property(e => e.FContactPerson)
                    .HasMaxLength(50)
                    .HasColumnName("fContactPerson");

                entity.Property(e => e.FContactPhone)
                    .HasMaxLength(50)
                    .HasColumnName("fContactPhone");

                entity.Property(e => e.FDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("fDistrict");

                entity.Property(e => e.FEducation)
                    .HasMaxLength(50)
                    .HasColumnName("fEducation");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FEmployeesType)
                    .HasMaxLength(50)
                    .HasColumnName("fEmployeesType");

                entity.Property(e => e.FFax)
                    .HasMaxLength(50)
                    .HasColumnName("fFax");

                entity.Property(e => e.FJobName)
                    .HasMaxLength(50)
                    .HasColumnName("fJobName");

                entity.Property(e => e.FJoblistId).HasColumnName("fJoblistID");

                entity.Property(e => e.FLanguage)
                    .HasMaxLength(50)
                    .HasColumnName("fLanguage");

                entity.Property(e => e.FLeaveSystem)
                    .HasMaxLength(50)
                    .HasColumnName("fLeaveSystem");

                entity.Property(e => e.FNeedPerson)
                    .HasMaxLength(50)
                    .HasColumnName("fNeedPerson");

                entity.Property(e => e.FOther).HasColumnName("fOther");

                entity.Property(e => e.FPostCode).HasColumnName("fPostCode");

                entity.Property(e => e.FSalary).HasColumnName("fSalary");

                entity.Property(e => e.FSalaryMode)
                    .HasMaxLength(50)
                    .HasColumnName("fSalaryMode");

                entity.Property(e => e.FWorkAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fWorkAddress");

                entity.Property(e => e.FWorkExp)
                    .HasMaxLength(50)
                    .HasColumnName("fWorkEXP");

                entity.Property(e => e.FWorkHours)
                    .HasMaxLength(50)
                    .HasColumnName("fWorkHours");

                entity.HasOne(d => d.FAccountNavigation)
                    .WithMany(p => p.TJobVacancies)
                    .HasForeignKey(d => d.FAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tJobVacancy_tCompanyBasic1");

                entity.HasOne(d => d.FJoblist)
                    .WithMany(p => p.TJobVacancies)
                    .HasForeignKey(d => d.FJoblistId)
                    .HasConstraintName("FK_tJobVacancy_tJobDirect");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.TJobVacancies)
                    .HasForeignKey(d => new { d.FCity, d.FDistrict })
                    .HasConstraintName("FK_tJobVacancy_tCityContrast");
            });

            modelBuilder.Entity<TLanguageForm>(entity =>
            {
                entity.HasKey(e => e.LangugeId);

                entity.ToTable("tLanguageForm");

                entity.Property(e => e.LangugeId).HasColumnName("LangugeID");

                entity.Property(e => e.LanguageName).HasMaxLength(50);
            });

            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasKey(e => e.FAccount);

                entity.ToTable("tMember");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(20)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FDateTime)
                    .HasMaxLength(50)
                    .HasColumnName("fDateTime");

                entity.Property(e => e.FGuid).HasColumnName("fGuid");

                entity.Property(e => e.FMemberType).HasColumnName("fMemberType");

                entity.Property(e => e.FPassword)
                    .IsRequired()
                    .HasMaxLength(48)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FSalt)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fSalt");
            });

            modelBuilder.Entity<TMemberCoverLetterTemp>(entity =>
            {
                entity.HasKey(e => e.CoverLetterId)
                    .HasName("PK_tMember_CoverLetter_Temp");

                entity.ToTable("tMemberCoverLetterTemp");

                entity.Property(e => e.CoverLetterId)
                    .ValueGeneratedNever()
                    .HasColumnName("CoverLetterID");

                entity.Property(e => e.CoverLetterContent).HasMaxLength(500);

                entity.Property(e => e.CoverLetterName).HasMaxLength(20);

                entity.Property(e => e.MemberId).HasMaxLength(20);
            });

            modelBuilder.Entity<TMemberLevel>(entity =>
            {
                entity.HasKey(e => e.FLevel);

                entity.ToTable("tMemberLevel");

                entity.Property(e => e.FLevel).HasColumnName("fLevel");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TMemberLevelRecord>(entity =>
            {
                entity.HasKey(e => e.CompanyTaxid)
                    .HasName("PK_MemberLevelRecord");

                entity.ToTable("tMemberLevelRecord");

                entity.Property(e => e.CompanyTaxid)
                    .HasMaxLength(50)
                    .HasColumnName("CompanyTAXID");

                entity.Property(e => e.Date).HasMaxLength(50);
            });

            modelBuilder.Entity<TMemberResumeSend>(entity =>
            {
                entity.HasKey(e => e.ResumeSendId)
                    .HasName("PK_tMember_Resume_Send");

                entity.ToTable("tMemberResumeSend");

                entity.Property(e => e.ResumeSendId).HasColumnName("ResumeSendID");

                entity.Property(e => e.ComReadOrNot).HasMaxLength(10);

                entity.Property(e => e.CompanyTaxid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CompanyTAXID");

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CoverLetter).HasMaxLength(500);

                entity.Property(e => e.CreatTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifyTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResumeId).HasColumnName("ResumeID");

                entity.Property(e => e.TimeToContact).HasMaxLength(50);
            });

            modelBuilder.Entity<TPhoto>(entity =>
            {
                entity.HasKey(e => e.FPhotoId);

                entity.ToTable("tPhoto");

                entity.Property(e => e.FPhotoId).HasColumnName("fPhotoID");

                entity.Property(e => e.FAccount)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FPhoto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fPhoto");

                entity.Property(e => e.FType)
                    .HasMaxLength(50)
                    .HasColumnName("fType");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_tProductInformation");

                entity.ToTable("tProduct");

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.ImgPath).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<TProductOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.MemberId })
                    .HasName("PK_ProductOrder");

                entity.ToTable("tProductOrder");

                entity.Property(e => e.OrderId).HasMaxLength(50);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasMaxLength(50);

                entity.Property(e => e.Invoice).HasMaxLength(50);

                entity.Property(e => e.ShipTo).HasMaxLength(50);
            });

            modelBuilder.Entity<TProductOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("tProductOrderDetail");

                entity.Property(e => e.OrderId).HasMaxLength(50);
            });

            modelBuilder.Entity<TQuestionDetail>(entity =>
            {
                entity.HasKey(e => new { e.FSubjectId, e.FQuestionId, e.FChoice })
                    .HasName("PK_tQuestionDetail_1");

                entity.ToTable("tQuestionDetail");

                entity.Property(e => e.FSubjectId)
                    .HasMaxLength(50)
                    .HasColumnName("fSubjectID");

                entity.Property(e => e.FQuestionId).HasColumnName("fQuestionID");

                entity.Property(e => e.FChoice)
                    .HasMaxLength(200)
                    .HasColumnName("fChoice");

                entity.Property(e => e.FCorrectAnswer).HasColumnName("fCorrectAnswer");

                entity.Property(e => e.FImage).HasColumnName("fImage");
            });

            modelBuilder.Entity<TQuestionList>(entity =>
            {
                entity.HasKey(e => new { e.FSubjectId, e.FQuestionId });

                entity.ToTable("tQuestionList");

                entity.Property(e => e.FSubjectId)
                    .HasMaxLength(50)
                    .HasColumnName("fSubjectID");

                entity.Property(e => e.FQuestionId).HasColumnName("fQuestionID");

                entity.Property(e => e.FLevel).HasColumnName("fLevel");

                entity.Property(e => e.FNotes).HasColumnName("fNotes");

                entity.Property(e => e.FQuestion)
                    .IsRequired()
                    .HasColumnName("fQuestion");

                entity.Property(e => e.FQuestionImage).HasColumnName("fQuestionImage");

                entity.Property(e => e.FQuestionTypeId).HasColumnName("fQuestionTypeID");

                entity.Property(e => e.FUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fUpdateTime");
            });

            modelBuilder.Entity<TReceipt>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK_Receipt");

                entity.ToTable("tReceipt");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.CompanyTaxid)
                    .HasMaxLength(50)
                    .HasColumnName("CompanyTAXID");

                entity.Property(e => e.EmergencyContactPerson).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactPersonEmail).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactPersonPhone).HasMaxLength(50);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewsFrom).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.OrderId).HasMaxLength(50);

                entity.Property(e => e.ReceiptTitle).HasMaxLength(50);

                entity.Property(e => e.Undertaker).HasMaxLength(50);

                entity.Property(e => e.UndertakerEmail).HasMaxLength(50);

                entity.Property(e => e.UndertakerPhone).HasMaxLength(50);
            });

            modelBuilder.Entity<TRelation>(entity =>
            {
                entity.HasKey(e => new { e.CompanyTaxid, e.FAccountEmail });

                entity.ToTable("tRelation");

                entity.Property(e => e.CompanyTaxid)
                    .HasMaxLength(50)
                    .HasColumnName("CompanyTAXID");

                entity.Property(e => e.FAccountEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fAccount(Email)");

                entity.Property(e => e.ClassCode).HasMaxLength(50);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.JobPosition).HasMaxLength(50);

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updater).HasMaxLength(50);
            });

            modelBuilder.Entity<TResultDescription>(entity =>
            {
                entity.HasKey(e => e.FTypeInfoId);

                entity.ToTable("tResultDescription");

                entity.Property(e => e.FTypeInfoId)
                    .ValueGeneratedNever()
                    .HasColumnName("fTypeInfoID");

                entity.Property(e => e.FResult)
                    .IsRequired()
                    .HasColumnName("fResult");

                entity.Property(e => e.FTestPaperId).HasColumnName("fTestPaperID");
            });

            modelBuilder.Entity<TSkill>(entity =>
            {
                entity.HasKey(e => e.FSkillId)
                    .HasName("PK_tSkill_1");

                entity.ToTable("tSkill");

                entity.Property(e => e.FSkillId).HasColumnName("fSkillID");

                entity.Property(e => e.FJobId).HasColumnName("fJobID");

                entity.Property(e => e.FSkillName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fSkillName");

                entity.HasOne(d => d.FJob)
                    .WithMany(p => p.TSkills)
                    .HasForeignKey(d => d.FJobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSkill_tSkill");
            });

            modelBuilder.Entity<TSkillGrade>(entity =>
            {
                entity.HasKey(e => new { e.FAccount, e.FSkillCategory });

                entity.ToTable("tSkillGrade");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(50)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FSkillCategory)
                    .HasMaxLength(50)
                    .HasColumnName("fSkillCategory");

                entity.Property(e => e.FGrade).HasColumnName("fGrade");

                entity.Property(e => e.FMemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fMemberName");
            });

            modelBuilder.Entity<TSkillTestPaper>(entity =>
            {
                entity.HasKey(e => new { e.TestPaper, e.TopicId });

                entity.ToTable("tSkillTestPaper");

                entity.Property(e => e.TestPaper).HasMaxLength(50);

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.Property(e => e.SkillJobClass).HasMaxLength(50);

                entity.Property(e => e.TopicAnswer).HasMaxLength(50);
            });

            modelBuilder.Entity<TStudentPoint>(entity =>
            {
                entity.HasKey(e => new { e.PointUsageId, e.FAccount })
                    .HasName("PK_StudentPoint");

                entity.ToTable("tStudentPoint");

                entity.Property(e => e.PointUsageId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PointUsageID");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(50)
                    .HasColumnName("fAccount");

                entity.Property(e => e.OrderId).HasMaxLength(50);

                entity.Property(e => e.PointDate).HasMaxLength(50);

                entity.Property(e => e.PointDescription).HasMaxLength(50);

                entity.Property(e => e.PointRecord).HasMaxLength(50);

                entity.Property(e => e.PointType).HasMaxLength(50);
            });

            modelBuilder.Entity<TStudioInformation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tStudioInformation");

                entity.Property(e => e.FClassCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fClassCategory");

                entity.Property(e => e.FClassLevel).HasColumnName("fClassLevel");

                entity.Property(e => e.FClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fClassName");

                entity.Property(e => e.FClassSkill)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fClassSkill");
            });

            modelBuilder.Entity<TSubmittedAnswer>(entity =>
            {
                entity.HasKey(e => e.FSn);

                entity.ToTable("tSubmittedAnswer");

                entity.Property(e => e.FSn)
                    .ValueGeneratedNever()
                    .HasColumnName("fSN");

                entity.Property(e => e.FMemberAccount)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fMemberAccount");

                entity.Property(e => e.FQuestionId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fQuestionID")
                    .IsFixedLength(true);

                entity.Property(e => e.FResultId).HasColumnName("fResultID");

                entity.Property(e => e.FSubjectId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fSubjectID");

                entity.Property(e => e.FSubmitAnswer)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("fSubmitAnswer");
            });

            modelBuilder.Entity<TTestPaper>(entity =>
            {
                entity.HasKey(e => e.FSn);

                entity.ToTable("tTestPaper");

                entity.Property(e => e.FSn).HasColumnName("fSN");

                entity.Property(e => e.FQuestionId).HasColumnName("fQuestionID");

                entity.Property(e => e.FSubjectId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fSubjectID");

                entity.Property(e => e.FTestPaperId).HasColumnName("fTestPaperID");
            });

            modelBuilder.Entity<TTestPaperBank>(entity =>
            {
                entity.HasKey(e => e.FTestPaperId);

                entity.ToTable("tTestPaperBank");

                entity.Property(e => e.FTestPaperId).HasColumnName("fTestPaperID");

                entity.Property(e => e.FDesignerAccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fDesignerAccount");

                entity.Property(e => e.FNote).HasColumnName("fNote");

                entity.Property(e => e.FSubjectId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fSubjectID");

                entity.Property(e => e.FTestPaperName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fTestPaperName");
            });

            modelBuilder.Entity<TTestResult>(entity =>
            {
                entity.HasKey(e => e.FResultId);

                entity.ToTable("tTestResult");

                entity.Property(e => e.FResultId)
                    .ValueGeneratedNever()
                    .HasColumnName("fResultID");

                entity.Property(e => e.FMemberAccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fMemberAccount");

                entity.Property(e => e.FTestDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fTestDateTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FTestGrade).HasColumnName("fTestGrade");

                entity.Property(e => e.FTestPaperId).HasColumnName("fTestPaperID");

                entity.Property(e => e.FTypeInfoId).HasColumnName("fTypeInfoID");

                entity.Property(e => e.FTypeInfoImage).HasColumnName("fTypeInfoImage");
            });

            modelBuilder.Entity<VGetDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_GetDate");

                entity.Property(e => e.Nowdate)
                    .HasMaxLength(50)
                    .HasColumnName("nowdate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
