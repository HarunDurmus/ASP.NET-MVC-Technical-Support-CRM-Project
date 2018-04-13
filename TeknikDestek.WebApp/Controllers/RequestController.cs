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
    public class RequestController : Controller
    {

        private RequestManager requestManager = new RequestManager();
        private SupporterManager supManager = new SupporterManager();
        private UserManager userManager = new UserManager();
        // GET: Request
        [Auth]
        public ActionResult Index()
        {
            if (CurrentSession.User.userStatus == "rs")
            {
                var req = requestManager.ListQueryable().Where(
                x => x.ResponsibleId == CurrentSession.User.Id);

                return View(req.ToList());
            }
            if (CurrentSession.User.userStatus == "sp")
            {
                var req = requestManager.ListQueryable().Where(
                x => x.SupportersId == CurrentSession.User.supId);

                return View(req.ToList());
            }


            return View(requestManager.List()); 
        }

        [Auth]
        public ActionResult Creat()
        {

            return View();
        }


        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creat(Request request)
        {
            
            if (ModelState.IsValid)
            {
                request.ResponsibleId = CurrentSession.User.Id;
     
                request.date = DateTime.Now;
                requestManager.Insert(request);
                return RedirectToAction("Index");
            }

            //ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", note.CategoryId);
            return View(request);
        }

        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request req = requestManager.Find(x => x.Id == id);
            if (req == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", note.CategoryId);
            return View(req);
        }
        [Auth]
        [HttpPost]
        public ActionResult Edit(Request request)
        {

            if (ModelState.IsValid)
            {
                Request db_note = requestManager.Find(x => x.Id == request.Id);
                db_note.description = request.description;
                /*db_note.CategoryId = note.CategoryId;
                db_note.Text = note.Text;
                db_note.Title = note.Title;*/

                requestManager.Update(db_note);

                return RedirectToAction("Index");
            }
          //  ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", note.CategoryId);
            return View(request);
        }

        [Auth]
        public ActionResult Assignment()
        {
            return View();
        }
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assignment(Request req)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Request> res = requestManager.Insert(req);
                return RedirectToAction("Index");
            }
            return View(req);
        }

    }
}