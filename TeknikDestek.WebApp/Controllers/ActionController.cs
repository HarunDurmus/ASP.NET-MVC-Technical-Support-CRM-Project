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
using TeknikDestek.WebApp.Models;

namespace TeknikDestek.WebApp.Controllers
{
    [Exc]
    public class ActionController : Controller
    {

        private ActionManager actionManager = new ActionManager();
        private RequestManager reqManager = new RequestManager();
        // GET: Company

        [Auth]
        public  ActionResult Index()
        {
            if (CurrentSession.User.userStatus == "rs")
            {
                var req = reqManager.ListQueryable().Where(
                x => x.ResponsibleId == CurrentSession.User.Id);

                return View(req.ToList());
            }
               
         
            return View(actionManager.List());
        }
        [Auth]
        [HttpGet]
        public ActionResult Creat()
        {
            return View();
        }
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creat(RAction raction)
        {
            if (ModelState.IsValid)
            {
                raction.status_bit = true;
                raction.dateLogged = DateTime.Now;
                //actionManager.Insert(Raction);
                BusinessLayerResult<RAction> act = actionManager.Insert(raction);
                if (act.Errors.Count > 0)
                {
                    act.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(raction);
                }
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
            RAction com = actionManager.Find(x => x.Id == id);
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
            RAction note = actionManager.Find(x => x.Id == id);
            actionManager.Delete(note);
            return RedirectToAction("Index");
        }

        [Auth]
        public ActionResult Details(int? id)
        {

            var req = actionManager.ListQueryable().Where(
                x => x.RequestId == id);

            return View(req.ToList());

                 
            
        }
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAction com = actionManager.Find(x => x.Id == id);
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
                RAction db_action = actionManager.Find(x => x.Id == company.Id);
                
               


                actionManager.Update(db_action);

                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", note.CategoryId);
            return View(company);
        }
    }
}