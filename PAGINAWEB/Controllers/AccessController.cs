using Microsoft.AspNetCore.Mvc;
using PAGINAWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAGINAWEB.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        private YourDatabase = new YourDatabase();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userist = db.UserMasters.ToList();
                    var user = userist.FirstOrDefault(x => x.User_email == model.email && x.Password == model.password);
                    LogMaster logMaster = new LogMaster();
                    SessionData sData = new SessionData();
                    if (user != null)
                    {
                        ViewBag.UserName = user.User_firstname + " " + user.User_lastname;
                        sData.UserId = user.User_id;
                        sData.UserFname = user.User_firstname;
                        sData.UserLname = user.User_lastname;
                        sData.UserEmail = user.User_email;
                        Session["Logindata"] = sData;
                        logMaster.Log_Msg = "login by user into system ";
                        logMaster.User_Fk_id = user.User_id;
                        logMaster.Create_date = System.DateTime.Now;
                        db.LogMasters.Add(logMaster);
                        Session["Logindata"] = sData;
                        ViewBag.message = "Successful login";
                        db.SaveChanges();
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("email", "Invalid login details");
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("email", e.Message);
                }
            }
            return View();
        }
        //Get: Logout
        [Route("logout")]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");





        }

    }
}
