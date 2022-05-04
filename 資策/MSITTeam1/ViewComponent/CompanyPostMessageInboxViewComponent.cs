using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class CompanyPostMessageInboxViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext _context;
        public CompanyPostMessageInboxViewComponent(helloContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(string companyTaxId)
        {
            //IEnumerable<TCompanyResumeReceiveViewModel> companyResumeReceive = null;
            var companyResumeReceive = from p in _context.TMemberResumeSends
                                       join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                                       from combin in pt.DefaultIfEmpty()
                                       join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                                       from combin2 in ps.DefaultIfEmpty()
                                       where p.CompanyTaxid.Equals(companyTaxId)
                                       select new
                                       {
                                           p,
                                           combin.FName,
                                           combin2.Name
                                       };
            TCompanyResumeReceiveViewModel vModel = new TCompanyResumeReceiveViewModel();
            List<TCompanyResumeReceiveViewModel> list = new List<TCompanyResumeReceiveViewModel>();
            foreach (var item in companyResumeReceive)
            {
                vModel.memRS = item.p;
                vModel.FCompanyName = item.FName;
                vModel.FStudentName = item.Name;
                list.Add(vModel);
            }
            return View(list);
        }
    }
}
