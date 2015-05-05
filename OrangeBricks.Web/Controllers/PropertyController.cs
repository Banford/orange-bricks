using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers
{
    public class PropertyController : Controller
    {
        [Authorize(Roles = "Seller")]
        public ActionResult Create()
        {
            return View();
        }
    }
}