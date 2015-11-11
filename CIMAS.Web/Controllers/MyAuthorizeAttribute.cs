using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CIMAS.DAL;
using CIMAS.DAL.AccountModel;

namespace CIMAS.Web.Controllers
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        //只需重载此方法，模拟自定义的角色授权机制   
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Roles == "")
            {
                return httpContext.User.Identity.IsAuthenticated;
            }
            else
            {
                if (httpContext.Session["CurrentUser"] == null) return false;
                CurrentUser currentUser = (CurrentUser)httpContext.Session["CurrentUser"];
                string currentRole = currentUser.RoleName;
                if (currentRole == "") return false;
                if (Roles.ToUpper().Contains(currentRole.Trim().ToUpper())) return true;

                return false;
            }
        }

        //返回用户对应的角色名称
        private string GetRole(string account)
        {
            //PurchaseInnerContext db = new PurchaseInnerContext();
            //USER_ACCOUNT user = db.USER_ACCOUNT.SingleOrDefault(p => p.ACCOUNT == account);
            //if (null == user)
            //    return "";
            //else
            //    return user.ROLE.CODE;

            return account;
        }
    }
}