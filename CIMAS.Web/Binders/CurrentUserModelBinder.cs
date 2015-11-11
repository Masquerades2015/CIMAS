using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMAS.DAL.AccountModel;

namespace CIMAS.Web.Binders
{
    public class CurrentUserModelBinder : IModelBinder
    {
        private const string sessionKey = "CurrentUser";
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            //获取Session中对象
            CurrentUser currentUser = (CurrentUser)controllerContext.HttpContext.Session[sessionKey];
            if (currentUser == null)
            {
                throw new Exception("访问超时，请重新登录！");
            }
            return currentUser;
        }
    }
}