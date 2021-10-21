using Microsoft.AspNetCore.Mvc;
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
    }
}
