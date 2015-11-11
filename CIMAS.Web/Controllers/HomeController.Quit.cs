using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMAS.DAL.AccountModel;

namespace CIMAS.Web.Controllers
{
    public partial class HomeController
    {
        [MyAuthorize()]
        public ActionResult Quit(CurrentUser currentUser)
        {
            ViewBag.RoleCode = currentUser.RoleCode;
            return View();
        }
    }
}