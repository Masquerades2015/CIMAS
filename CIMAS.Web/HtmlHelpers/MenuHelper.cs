using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;
using System.Xml.Linq;
using CIMAS.DAL.AccountModel;

namespace HiTechDevelopTrack.Web.HtmlHelpers
{
    public static class MenuHelper
    {   
        private static HttpServerUtilityBase server = null;
        private static HttpRequestBase request = null;
        private static UrlHelper urlHelper = null;
        private static RouteValueDictionary routeDictionary = null;

        public static MvcHtmlString Menu(this HtmlHelper helper)
        {
            server = helper.ViewContext.RequestContext.HttpContext.Server;
            request = helper.ViewContext.RequestContext.HttpContext.Request;
            urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            routeDictionary = helper.ViewContext.RequestContext.RouteData.Values;
            HtmlHelper htmlHelper = new HtmlHelper(helper.ViewContext, helper.ViewDataContainer);

            //获取当前用户信息
            //TalentMISDbContext db = new TalentMISDbContext();
            //string current_account = helper.ViewContext.RequestContext.HttpContext.User.Identity.Name;
            //Account account = db.Accounts.FirstOrDefault(x => x.UserName.Trim().ToUpper() == current_account.Trim().ToUpper());
            //string roleCode = account.RoleCode;
            string roleCode = ((CurrentUser)helper.ViewContext.RequestContext.HttpContext.Session["CurrentUser"]).RoleCode;

            //加载菜单xml文件
            //string xmlPath = server.MapPath(url.Content("~/Menu.xml"));//当禁用Cookie时会话标识会嵌入URL中，此时该行代码结果就不正确了！（夏春涛）
            string webRootPath = server.MapPath("/");
            string xmlPath = webRootPath.TrimEnd('\\') + "\\Menu.xml";
            XDocument doc = XDocument.Load(xmlPath);
            var xmlNav = doc.Root;

            //获取所有符合条件的一级菜单（其中包括所有二级菜单）
            var nav1Items = xmlNav
                    .Elements("NavItem")
                    .Where(p => p.Attribute("roles").Value.Trim() == "" ||
                                p.Attribute("roles").Value.Trim().ToUpper().Contains(roleCode.ToUpper()));

            foreach (var nav1 in nav1Items)
            {
                //删除一级菜单下不符合条件的二级菜单
                var nav2List = nav1.Elements("NavItem").ToList();
                foreach (var nav2 in nav2List)
                {
                    if (nav2.Attribute("roles").Value.Trim() == "")//任意角色均可访问的二级菜单
                    {
                        continue;
                    }
                    bool isPermitted = nav2.Attribute("roles").Value.ToUpper().Contains(roleCode.Trim().ToUpper());
                    if (!isPermitted)//用户角色不再许可范围内
                    {
                        nav1.Elements("NavItem")
                            .Where(p => p.Attribute("code").Value.Trim().ToUpper() == nav2.Attribute("code").Value.Trim().ToUpper())
                            .Remove();
                    }
                }
            }

            //如果一级菜单下面没有二级菜单，则删除该一级菜单 
            nav1Items.Where(p => p.Elements().Count() == 0).Remove();
            //----
            MvcHtmlString result = htmlHelper.Partial("Menu", nav1Items);
            return result;
        }

        public static MvcHtmlString Menu_Ver2(this HtmlHelper helper)
        {
            server = helper.ViewContext.RequestContext.HttpContext.Server;
            request = helper.ViewContext.RequestContext.HttpContext.Request;
            urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            routeDictionary = helper.ViewContext.RequestContext.RouteData.Values;
            HtmlHelper htmlHelper = new HtmlHelper(helper.ViewContext, helper.ViewDataContainer);

            //获取当前用户信息
            //TalentMISDbContext db = new TalentMISDbContext();
            //string current_account = helper.ViewContext.RequestContext.HttpContext.User.Identity.Name;
            //Account account = db.Accounts.FirstOrDefault(x => x.UserName.Trim().ToUpper() == current_account.Trim().ToUpper());
            //string roleCode = account.RoleCode;
            //if()
            //注释（无用户登录，备用）
            //if (HttpContext.Current.Session["CurrentUser"] == null) return new MvcHtmlString("");
            //string roleCode = ((CurrentUser)HttpContext.Current.Session["CurrentUser"]).RoleCode;
            string roleCode = "";

            //加载菜单xml文件
            //string xmlPath = server.MapPath(url.Content("~/Menu.xml"));//当禁用Cookie时会话标识会嵌入URL中，此时该行代码结果就不正确了！（夏春涛）
            string webRootPath = server.MapPath("/");
            string xmlPath = webRootPath.TrimEnd('\\') + "\\Menu_Ver2.xml";
            XDocument doc = XDocument.Load(xmlPath);
            var xmlNav = doc.Root;

            //获取所有符合条件的一级菜单（其中包括所有二级菜单）
            var nav1Items = xmlNav
                    .Elements("NavItem")
                    .Where(p => p.Attribute("roles").Value.Trim() == "" ||
                                p.Attribute("roles").Value.Trim().ToUpper().Contains(roleCode.ToUpper()));

            foreach (var nav1 in nav1Items)
            {
                //删除一级菜单下不符合条件的二级菜单
                var nav2List = nav1.Elements("NavItem").ToList();
                foreach (var nav2 in nav2List)
                {
                    if (nav2.Attribute("roles").Value.Trim() == "")//任意角色均可访问的二级菜单
                    {
                        continue;
                    }
                    bool isPermitted = nav2.Attribute("roles").Value.ToUpper().Contains(roleCode.Trim().ToUpper());
                    if (!isPermitted)//用户角色不再许可范围内
                    {
                        nav1.Elements("NavItem")
                            .Where(p => p.Attribute("code").Value.Trim().ToUpper() == nav2.Attribute("code").Value.Trim().ToUpper())
                            .Remove();
                    }
                }
            }

            //如果一级菜单下面没有二级菜单，则删除该一级菜单 
            nav1Items.Where(p => p.Elements().Count() == 0).Remove();
            //----
            MvcHtmlString result = htmlHelper.Partial("Menu_Ver2", nav1Items);
            return result;
        }

    }
}