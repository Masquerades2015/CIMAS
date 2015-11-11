using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMAS.DAL;
using CIMAS.DAL.AccountModel;

namespace CIMAS.Web.Controllers
{
    public class AccountController : MyControllerBase
    {
        //
        // GET: /Account/

        [MyAuthorize()]
        public ActionResult ShowAccountInfo(CurrentUser currentUser)
        {
            string userName = currentUser.UserName;
            var account = db.Accounts.FirstOrDefault(x => x.UserName == userName);
            return View(account);
        }

        [MyAuthorize()]
        public ActionResult EditAccountInfo(CurrentUser currentUser)
        {
            string userName = currentUser.UserName;
            var account = db.Accounts.FirstOrDefault(x => x.UserName == userName);
            return View(account);
        }

        [MyAuthorize()]
        [HttpPost]
        public ActionResult EditAccountInfo(CurrentUser currentUser, [Bind(Exclude = "TrueName")]Account model, string confirm)
        {
            Account account = db.Accounts.FirstOrDefault(x => x.UserName == currentUser.UserName);
            if (account == null) throw new Exception("系统异常！");

            ModelState.Remove("TrueName");

            if (!ModelState.IsValid) return View(account);

            if (model.Password.Trim().Length < 6)
                ModelState.AddModelError("Password", "密码长度不能低于6位");
            if (!string.Equals(model.Password, confirm))
                ModelState.AddModelError("Password", "密码不一致");

            if (!ModelState.IsValid) return View(account);

            account.Password = model.Password;
            db.SaveChanges();

            return RedirectToAction("ShowAccountInfo", new { code = "ZZ01" });
        }

        [MyAuthorize()]
        public ActionResult ShowCurrentAccountInfo(CurrentUser currentUser)
        {
            //currentUser.IP = Request.UserHostAddress;
            return View(currentUser);
        }

    }
}
