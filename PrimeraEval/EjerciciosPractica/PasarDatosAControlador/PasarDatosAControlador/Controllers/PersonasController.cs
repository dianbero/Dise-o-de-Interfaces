using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasarDatosAControlador.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()//Mando datos a la vista de la página original
        {
            //Instancio objeto tipo clsPersona
            Models.clsPersona objPersona = new Models.clsPersona();

            return View(objPersona); 
        }

        //Implementación de envío de datos a la otra vista de Datos Modificados
        [HttpPost]//porque enviamos datos introducidos en una vista a otra donde los mostramos
        public ActionResult DatosPersonasModificados(Models.clsPersona personas) //Recibe un objeto de tipo clsPersona
        {
            return View("DatosPersonasModificados", personas);
        }
    }
}