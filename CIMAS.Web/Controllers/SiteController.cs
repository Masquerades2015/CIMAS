using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMAS.Web.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        public string Version()
        {

            return "Ver1.3.0-20140128";
        }

        public string ZhTitle()
        {
            return "高新技术企业信息备案系统";
        }

        public string EnTitle()
        {
            return "HiTechDevelopTrack";
        }

        public string Copyright()
        {
            return "2014";
        }

    }
}
