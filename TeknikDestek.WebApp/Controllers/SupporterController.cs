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
    public class SupporterController : Controller
    {


        private SupporterManager supManager = new SupporterManager();
        [AuthMsp]
        public ActionResult Index()
        {
            return View(supManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supporter responsible = supManager.Find(x => x.Id == id.Value);

            if (responsible == null)
            {
                return HttpNotFound();
            }

            return View(responsible);
        }

        public ActionResult Create()
        {
            Supporter sup = supManager.List().OrderByDescending(x => x.Id).FirstOrDefault();
            if (sup == null)
            {
                return HttpNotFound();
            }
            return View(sup);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supporter supporter)
        {


            if (ModelState.IsValid)
            {
                supporter.user.userStatus = "sp";
                BusinessLayerResult<Supporter> res = supManager.Insert(supporter);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(supporter);
                }

                return RedirectToAction("Index");
            }

            return View(supporter);
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

            Supporter responsible = supManager.Find(x => x.Id == id.Value);

            if (responsible == null)
            {
                return HttpNotFound();
            }

            return View(responsible);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supporter supporter)
        {


            if (ModelState.IsValid)
            {
                BusinessLayerResult<Supporter> res = supManager.Update(supporter);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(supporter);
                }

                return RedirectToAction("Index");
            }
            return View(supporter);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supporter responsible = supManager.Find(x => x.Id == id.Value);

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
            Supporter supporter = supManager.Find(x => x.Id == id);
            supManager.Delete(supporter);

            return RedirectToAction("Index");
        }


    }
}