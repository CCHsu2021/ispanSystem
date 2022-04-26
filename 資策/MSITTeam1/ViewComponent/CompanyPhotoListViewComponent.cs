using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class CompanyPhotoListViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;

        public CompanyPhotoListViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke(string taxid)
        {
            var photo = hello.TPhotos.Where(p => p.FAccount == taxid);
            return View(photo);
        }
    }
}
