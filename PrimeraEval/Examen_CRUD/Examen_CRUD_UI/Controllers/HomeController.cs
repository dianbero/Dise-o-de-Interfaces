using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_CRUD_Entities;
using Examen_CRUD_BL.Lists;

namespace Examen_CRUD_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                clsListadoDepartamentosBL listadoDepartamentos = new clsListadoDepartamentosBL();
                return View(listadoDepartamentos.ListadoCompletoDepartamentos());
            }
            catch(Exception e)
            {
                ViewBag.Error = "Error";
                return View();
            }           
        }
    }
}