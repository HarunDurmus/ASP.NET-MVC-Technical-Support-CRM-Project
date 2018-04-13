using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikDestek.BusinessLayer;
using TeknikDestek.BusinessLayer.Result;
using TeknikDestek.Entities;
using TeknikDestek.Entities.ValueObject;
using TeknikDestek.WebApp.Filters;
using TeknikDestek.WebApp.Models;

namespace TeknikDestek.WebApp.Controllers
{
    public class HomeController : Controller
    {

        private UserManager userManager = new UserManager();
        private SupporterManager SupporterManager = new SupporterManager();
        private RequestManager requestManager = new RequestManager();

        // GET: Home
        public ActionResult Index()
        {
            BusinessLayer.test test = new BusinessLayer.test();
            return View();
        }
        [Auth]
        [AuthMsp]
        public ActionResult SupIndex()
        {
                return View(requestManager.List());   
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<User> res = userManager.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    // Hata koduna göre özel işlem yapmamız gerekirse..
                    // Hatta hata mesajına burada müdahale edilebilir.
                    // (Login.cshtml'deki kısmında açıklama satırı şeklinden kurtarınız)
                    //
                    //if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                    //{
                    //    ViewBag.SetLink = "http://Home/Activate/1234-4567-78980";
                    //}

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(model);
                }
                //var req = SupporterManager.ListQueryable().Where(x => x.user.Id == CurrentSession.User.Id).Where(x => x.manager_id != null);
                //var req = SupporterManager.List(x => x.user.Id == CurrentSession.User.Id).Where(x => x.manager_id != null);
                var req2 = SupporterManager.Find(x => x.manager_id != null);
       
                CurrentSession.Set<User>("login", res.Result); // 'a kullanıcı bilgi saklama..
                if (CurrentSession.User.userStatus == "sp" && req2.user.Id == CurrentSession.User.Id )
                {
                    return RedirectToAction("SupIndex");
                }
                else
                {
                    return RedirectToAction("Index");   // yönlendirme..
                }
                
            }

            return View(model);
        }

        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }


        public ActionResult HasError()
        {
            return View();
        }
    }
}