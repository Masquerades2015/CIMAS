using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CIMAS.DAL.AccountModel;

namespace CIMAS.Web.Controllers
{
    public partial class HomeController
    {
        #region 用户登录
        public ActionResult Login()
        {
            Session.Clear();//清除所有session变量
            LoginModel model = new LoginModel();
            string userName = (Request.QueryString["userName"] ?? "").ToString();
            if (userName == "") return View(model);

            var account = db.Accounts.FirstOrDefault(x => x.UserName == userName);
            if (account != null)
            {
                model.UserName = userName;
                model.Password = account.Password;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View();

            var account = db.Accounts.FirstOrDefault(x =>
                x.UserName == model.UserName);

            //注意：此处不把password的比较放到LINQ中，因为数据库默认是不区分大小写的！！！！！
            if (account == null || account.Password != model.Password)//验证没通过
            {
                ModelState.AddModelError("error", "用户名或密码错误！");
                return View();
            }


            ////验证通过
            //FormsAuthentication.SetAuthCookie(account.UserName, false);

            //CurrentUser currentUser = new CurrentUser();
            ////currentUser.RoleCode = account.RoleCode;
            ////currentUser.RoleName = account.AccountRole.Name;
            //currentUser.TrueName = account.UserName;
            //currentUser.UserName = account.UserName;

            ////企业账号
            //if (account.RoleCode.ToUpper().Trim().Equals("Enterprise".ToUpper()))
            //{
            //    currentUser.EnterpriseID = account.Enterprise.ID;
            //    Session["CurrentUser"] = currentUser;
            //    return RedirectToAction("EditBasicInfo", "enterprise", new { code = "HH01" });
            //}
            ////管理员账号
            //if (account.RoleCode.ToUpper().Trim().Equals("SysAdmin".ToUpper()))
            //{
            //    Session["CurrentUser"] = currentUser;
            //    return RedirectToAction("ShowEnterpriseList", "Admin", new { code = "DD01" });
            //}

           

            return View();
        }

        #endregion
    }
}