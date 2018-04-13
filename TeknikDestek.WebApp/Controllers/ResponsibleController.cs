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
    [Auth]
    [AuthAdmin]
    [Exc]
    public class ResponsibleController : Controller
    {


        private ResponsibleManager responManager = new ResponsibleManager();
        

        public ActionResult Index()
        {
            return View(responManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Responsible responsible = responManager.Find(x => x.Id == id.Value);

            if (responsible == null)
            {
                return HttpNotFound();
            }

            return View(responsible);
        }

        public ActionResult Create()
        {
            

            Responsible responsible = responManager.List().OrderByDescending(x => x.Id).FirstOrDefault();
            
            
            if (responsible == null)
            {
                return HttpNotFound();
            }


            /*var req = responManager.ListQueryable().Where(x => x.user.supId == null).
            OrderByDescending(x => x.user.resId).Max(x => x.user.resId);*/

            //(x => x.user.supId == null).OrderByDescending(x => x.user.resId).FirstOrDefault();

            //ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", note.CategoryId);
            return View(responsible);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Responsible responsible)
        {
            
            if (ModelState.IsValid)
            {
                responsible.user.userStatus = "rs";
                BusinessLayerResult<Responsible> res = responManager.Insert(responsible);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(responsible);
                }

                return RedirectToAction("Index");
            }

            return View(responsible);
            /*
            if (ModelState.IsValid)
            {
                
                responManager.Insert(responsible);
                return RedirectToAction("Index");
            }
            return View("Index");*/
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Responsible responsible = responManager.Find(x => x.Id == id.Value);

            if (responsible == null)
            {
                return HttpNotFound();
            }

            return View(responsible);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Responsible responsible)
        {
            

            if (ModelState.IsValid)
            {
                BusinessLayerResult<Responsible> res = responManager.Update(responsible);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(responsible);
                }

                return RedirectToAction("Index");
            }
            return View(responsible);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Responsible responsible = responManager.Find(x => x.Id == id.Value);

            if (responsible == null)
            {
                return HttpNotFound();
            }

            return View(responsible);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsible responsible = responManager.Find(x => x.Id == id);
            responManager.Delete(responsible);

            return RedirectToAction("Index");
        }
    }
}