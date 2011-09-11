using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auctionbaseUI.Models;
using auctionbaseUI.Models.Authentication;
using System.Web.Security;

namespace auctionbaseUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        // get: /Acount/Signup
        public ActionResult SignUp() {

            return View("SignUp");
        }

        // post: /Account/Signup
        [HttpPost]
        public ActionResult SignUp(UserLoginViewModel user) {

            try {
                if (ModelState.IsValid) {
                UserManager userManager = new UserManager();
                userManager.Add(user);
                FormsAuthentication.SetAuthCookie(user.userName, false);
                return RedirectToAction("Welcome", "Home");}
            } catch(Exception e) {
                return View(user);
            }

            return View(user);

            }

        }
    
    
}
