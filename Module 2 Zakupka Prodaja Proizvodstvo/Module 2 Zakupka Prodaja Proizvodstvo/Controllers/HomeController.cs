using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


    }
}