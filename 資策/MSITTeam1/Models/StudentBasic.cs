using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentBasic
    {
        public StudentBasic()
        {
            StudentEducations = new HashSet<StudentEducation>();
            StudentLanguages = new HashSet<StudentLanguage>();
            StudentPortfolios = new HashSet<StudentPortfolio>();
            StudentReflections = new HashSet<StudentReflection>();
            StudentResumes = new HashSet<StudentResume>();
            StudentSkills = new HashSet<StudentSkill>();
            StudentWorkExperiences = new HashSet<StudentWorkExperience>();
        }

        public string FAccount { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactAddress { get; set; }
        public string Autobiography { get; set; }
        public string Portrait { get; set; }
        public string FClassMessage { get; set; }
        public string FCompany { get; set; }
        public string FCity { get; set; }
        public string FDistrict { get; set; }
        public byte[] FPassword { get; set; }
        public byte[] FSalt { get; set; }
        public string FGuid { get; set; }
        public string FDateTime { get; set; }

        public virtual ICollection<StudentEducation> StudentEducations { get; set; }
        public virtual ICollection<StudentLanguage> StudentLanguages { get; set; }
        public virtual ICollection<StudentPortfolio> StudentPortfolios { get; set; }
        public virtual ICollection<StudentReflection> StudentReflections { get; set; }
        public virtual ICollection<StudentResume> StudentResumes { get; set; }
        public virtual ICollection<StudentSkill> StudentSkills { get; set; }
        public virtual ICollection<StudentWorkExperience> StudentWorkExperiences { get; set; }
    }
}
