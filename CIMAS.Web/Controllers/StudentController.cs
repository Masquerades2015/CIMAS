using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMAS.DAL;

namespace CIMAS.Web.Controllers
{
    public class StudentController : MyControllerBase
    {
        //
        // GET: /Student/

        public ActionResult List()
        {
            return View(db.StuBasicIfoes);//view的参数是什么意思?
            
        }

        public ActionResult Edit(int id = 0)
        {
            StuBasicIfo student = new StuBasicIfo();
            if (id > 0)
            {
                student = db.StuBasicIfoes.FirstOrDefault(x => x.ID == id);
                if (student == null)
                {
                    throw new Exception("您访问的路径有误！");
                }
            }

            //var types = from m in db.DictExperienceTypes
            //            select m;
            //List<SelectListItem> list = new List<SelectListItem>();
            //foreach (var category in types)
            //{
            //    list.Add(new SelectListItem { Text = category.Name, Value = category.Code });
            //}
            //ViewBag.typelists = list;
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(int id, StuBasicIfo model)
        {
            if (model.Birthdate == null)
            {
                ModelState.AddModelError("Date", "时间输入无效");
            }
            else
            {
                DateTime a = (DateTime)model.Birthdate;
                if (a > DateTime.Now || a.Year < 1980)
                {
                    ModelState.AddModelError("Birthdate", "时间输入无效");
                }
            }
            
            if (ModelState.IsValid)  // 什么意思
            {
                if (id > 0)
                {
                    StuBasicIfo oldmodel = db.StuBasicIfoes.FirstOrDefault(x => x.ID == model.ID);
                    oldmodel.StuCode = model.StuCode;
                    oldmodel.Name = model.Name;
                    oldmodel.Sex = model.Sex;
                    oldmodel.Birthdate = model.Birthdate;
                }
                else
                {
                    
                    db.StuBasicIfoes.Add(model);
                }
                db.SaveChanges();
                return RedirectToAction("List", new { code = "HH02" });
           
            }
            else
            {
                return Edit(id);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            StuBasicIfo model = db.StuBasicIfoes.FirstOrDefault(x => x.ID == id);
            if (model == null)
            {
                throw new Exception("您访问的路径有误！");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]  //后面的ActionName什么意思
        public ActionResult DeleteConfirmed(int id)
        {
            StuBasicIfo model = db.StuBasicIfoes.FirstOrDefault(x => x.ID == id);
            if (model == null)
            {
                throw new Exception("您访问的路径有误！");
            }
            db.StuBasicIfoes.Remove(model);
            db.SaveChanges();
            return RedirectToAction("ShowAffirmAward", new { code = "HH02" });
        }
    }
}
