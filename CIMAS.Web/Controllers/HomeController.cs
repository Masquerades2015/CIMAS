using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CIMAS.Web.Controllers
{
    public partial class HomeController : MyControllerBase
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public string UserInfo()
        {
            string account = User.Identity.Name;
            string userInfo = "";

            userInfo += "欢迎您：张三";
            userInfo += "（" + "企业填报负责人" + "）　";

            //userInfo += "登录时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "　";
            //userInfo += "登录IP：" + Request.UserHostAddress;
            return userInfo;
        }

        //显示当前页的导航路径
        public string NavPath(string code = "HH01")
        {
            var xmlNav = XElement.Load(Server.MapPath("~/Menu_Ver2.xml"));
            //获取当前菜单的名称
            var xmlNavItem2 = xmlNav.Descendants().FirstOrDefault(p => p.Attribute("code").Value.Trim().ToUpper() == code.Trim().ToUpper());
            //获取当前菜单的父级名称(注：不要使用code的编码规律(如父级以00结尾)，因为此规律可能会变，不可靠！
            //                           我们只把code当作无意义的菜单项的唯一标识-20130714)
            var xmlNavItem1 = xmlNavItem2.Parent;

            string parentName = xmlNavItem1.Attribute("title").Value;//一级菜单名称
            string subName = xmlNavItem2.Attribute("title").Value;//二级菜单名称

            string navPath = parentName + " ><strong class=\"color1\">" + subName + "</strong>";

            return navPath;
        }
    }
}
