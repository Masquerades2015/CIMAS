using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMAS.DAL;

namespace CIMAS.Web.Controllers
{
    public class PersonalBasicIfoController : Controller
    {
        private CIMASDbContext db = new CIMASDbContext();

        //
        // GET: /PersonalBasicIfo/

        public ActionResult Index(int id=1)
        {
            var stubasicifoes = db.StuBasicIfoes.FirstOrDefault(x=>x.ID == id);
            
            return View(stubasicifoes);
        }

        //
        // GET: /PersonalBasicIfo/Edit/5

        public ActionResult Edit(int id = 1)
        {
            StuBasicIfo stubasicifo = db.StuBasicIfoes.Find(id);
            if (stubasicifo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DictFamilyOriginID = new SelectList(db.DictFamilyOrigins, "ID", "Type", stubasicifo.DictFamilyOriginID);
            ViewBag.DictNationID = new SelectList(db.DictNations, "ID", "Name", stubasicifo.DictNationID);
            ViewBag.DictPoliticsStatusID = new SelectList(db.DictPoliticsStatus, "ID", "Type", stubasicifo.DictPoliticsStatusID);
            ViewBag.DictProfClassID = new SelectList(db.DictProfClasses, "ID", "ClassCode", stubasicifo.DictProfClassID);
            ViewBag.DictProfNameID = new SelectList(db.DictProfNames, "ID", "Name", stubasicifo.DictProfClass.DictProfNameID);
            ViewBag.DictRegisterID = new SelectList(db.DictRegisters, "ID", "Type", stubasicifo.DictRegisterID);
            ViewBag.DictStuSourceID = new SelectList(db.DictStudentSources, "ID", "Type", stubasicifo.DictStuSourceID);
            return View(stubasicifo);
        }

        //
        // POST: /PersonalBasicIfo/Edit/5

        [HttpPost]
        public ActionResult Edit(StuBasicIfo stubasicifo)
        {
            if (string.IsNullOrEmpty(stubasicifo.Name))
            {
                ModelState.AddModelError("Name", "亲~，该信息不能为空");
            }
            else if(string.IsNullOrEmpty(stubasicifo.Sex))
            {
                ModelState.AddModelError("Sex", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.DictNationID.ToString()))
            {
                ModelState.AddModelError("DictNationID", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.StuCode))
            {
                ModelState.AddModelError("StuCode", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.BirthPlace))
            {
                ModelState.AddModelError("BirthPlace", "亲~，该信息不能为空");
            }
            else if ((stubasicifo.IDCardNumber).Length!=18)
            {
                ModelState.AddModelError("IDCardNumber", "亲~，请填写正确的身份证信息");
            }
            else if ((stubasicifo.ZIPCode).Length!=6)
            {
                ModelState.AddModelError("Sex", "亲~，请填写正确的邮政编码信息");
            }
            else if (((DateTime)stubasicifo.Birthdate)>DateTime.Now)
            {
                ModelState.AddModelError("Birthdate", "亲~，请输入正确的信息");
            }
            else if (string.IsNullOrEmpty(stubasicifo.Birthdate.ToString()))
            {
                ModelState.AddModelError("Birthdate", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.DictRegisterID.ToString()))
            {
                ModelState.AddModelError("DictRegisterID", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.DictPoliticsStatusID.ToString()))
            {
                ModelState.AddModelError("DictPoliticsStatusID", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.TelephoneNum))
            {
                ModelState.AddModelError("TelephoneNum", "亲~，该信息不能为空");
            }
            else if ((stubasicifo.TelephoneNum).Length!=11)
            {
                ModelState.AddModelError("TelephoneNum", "亲~，请填写正确的手机号码");
            }
            else if (string.IsNullOrEmpty(stubasicifo.QQNum))
            {
                ModelState.AddModelError("QQNum", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.DictStuSourceID.ToString()))
            {
                ModelState.AddModelError("DictStuSourceID", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.FamilyAddress))
            {
                ModelState.AddModelError("FamilyAddress", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.PersonalExperience))
            {
                ModelState.AddModelError("PersonalExperience", "亲~，该信息不能为空");
            }
            else if (string.IsNullOrEmpty(stubasicifo.Specialty))
            {
                ModelState.AddModelError("Specialty", "亲~，该信息不能为空");
            }
            if (ModelState.IsValid)
            {
                db.Entry(stubasicifo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.DictFamilyOriginID = new SelectList(db.DictFamilyOrigins, "ID", "Type", stubasicifo.DictFamilyOriginID);
            ViewBag.DictNationID = new SelectList(db.DictNations, "ID", "Name", stubasicifo.DictNationID);
            ViewBag.DictPoliticsStatusID = new SelectList(db.DictPoliticsStatus, "ID", "Type", stubasicifo.DictPoliticsStatusID);
            ViewBag.DictProfClassID = new SelectList(db.DictProfClasses, "ID", "ClassCode", stubasicifo.DictProfClassID);
            ViewBag.DictProfNameID = new SelectList(db.DictProfNames, "ID", "Name", stubasicifo.DictProfClass.DictProfNameID);
            ViewBag.DictRegisterID = new SelectList(db.DictRegisters, "ID", "Type", stubasicifo.DictRegisterID);
            ViewBag.DictStuSourceID = new SelectList(db.DictStudentSources, "ID", "Type", stubasicifo.DictStuSourceID);
            return View(stubasicifo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}