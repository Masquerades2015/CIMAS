using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CIMAS.DAL;

namespace CIMAS.Web.Controllers
{
    public class MyControllerBase : Controller
    {

        protected CIMASDbContext db = new CIMASDbContext();


    }
}