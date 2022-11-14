using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using WebAPPRoutingConfiguration.Models;

namespace WebAPPRoutingConfiguration.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Password == "12345678" && model.Username == "user@gmail.com")
                {
                    HttpContext.Session.SetString("key", "User");
                    
                }
                else if(model.Password == "12345678" && model.Username == "admin@gmail.com")
                {
                    HttpContext.Session.SetString("key", "Admin");                                                                                                              
                }
                else
                {
                    HttpContext.Session.SetString("key", "");
                }
                ViewBag.Key = HttpContext.Session.GetString("key");
                return RedirectToAction("Index", "Home", new { area = ViewBag.Key });
            }
            return View();
        }
    }
}
