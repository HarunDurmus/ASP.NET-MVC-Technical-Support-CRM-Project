using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeknikDestek.BusinessLayer;
using TeknikDestek.BusinessLayer.Result;
using TeknikDestek.Entities;
using TeknikDestek.WebApp.Filters;

namespace TeknikDestek.WebApp.Controllers
{
    [Exc]
    [AuthAdmin]
    public class CompanyController : Controller
    {

       
        private CompanyManager companyManager = new CompanyManager();

        // GET: Company
        [Auth]
        public ActionResult Index()
        {
            return View(companyManager.List());
        }
        [Auth]
        public ActionResult Creat( )
        {
            
            return View();
        }
        [Auth]
        [HttpPost]
        public ActionResult Creat(Company company)
        {
            if (ModelState.IsValid)
            {
                companyManager.Insert(company);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company com = companyManager.Find(x => x.Id == id);
            if (com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }

        [Auth]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company note = companyManager.Find(x => x.Id == id);
            companyManager.Delete(note);
            return RedirectToAction("Index");
        }

        [Auth]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company com = companyManager.Find(x => x.Id == id);
            if (com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company com = companyManager.Find(x => x.Id == id);
            if (com == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", note.CategoryId);
            return View(com);
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            

            if (ModelState.IsValid)
            {
                Company db_note = companyManager.Find(x => x.Id == company.Id);
                db_note.email = company.email;
                db_note.phoneNumber = company.phoneNumber;
                db_note.LocationId = company.LocationId;


                companyManager.Update(db_note);

                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", note.CategoryId);
            return View(company);
        }




    }
}