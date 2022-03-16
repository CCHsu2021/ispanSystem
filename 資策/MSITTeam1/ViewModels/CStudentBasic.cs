using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CStudentBasic
    {
        private StudentBasic _stu = null;
        public CStudentBasic()
        {
            _stu = new StudentBasic();
        }
        public StudentBasic stu { get { return _stu; } set { _stu = value; } }
        public string FAccount { get { return this.stu.FAccount; } set { this.stu.FAccount = value; } }
        public string Name { get { return this.stu.Name; } set { this.stu.Name = value; } }
        public string Gender { get { return this.stu.Gender; } set { this.stu.Gender = value; } }
        public string BirthDate { get { return this.stu.BirthDate; } set { this.stu.BirthDate = value; } }
        public string Email { get { return this.stu.Email; } set { this.stu.Email = value; } }
        public string Phone { get { return this.stu.Phone; } set { this.stu.Phone = value; } }
        public string ContactAddress { get { return this.stu.ContactAddress; } set { this.stu.ContactAddress = value; } }
        public string Autobiography { get { return this.stu.Autobiography; } set { this.stu.Autobiography = value; } }
        public byte[] Portrait { get { return this.stu.Portrait; } set { this.stu.Portrait = value; } }
        public string FClassMessage { get { return this.stu.FClassMessage; } set { this.stu.FClassMessage = value; } }
        public string FCompany { get { return this.stu.FCompany; } set { this.stu.FCompany = value; } }
        public string FCity { get { return this.stu.FCity; } set { this.stu.FCity = value; } }
        public string FDistrict { get { return this.stu.FDistrict; } set { this.stu.FDistrict = value; } }
    }
}
