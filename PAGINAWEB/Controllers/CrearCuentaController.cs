using Microsoft.AspNetCore.Mvc;
using PAGINAWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAGINAWEB.Controllers
{
    public class CrearCuentaController : Controller
    {
        public IActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegistrationModel model)
        {
            UserMaster userMaster = new UserMaster();
            userMaster.User_id = model.User_id;
            userMaster.User_firstname = model.User_firstname;
            userMaster.User_lastname = model.User_lastname;
            userMaster.User_email = model.User_email;
            if (model.Password == model.ConfirmPassword)
            {
                userMaster.Password = model.Password;
            }
            //userMaster.Create_date = System.DateTime.Now;
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.UserMasters.Add(userMaster);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }





    }
}
