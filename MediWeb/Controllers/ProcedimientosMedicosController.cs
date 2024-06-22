using MediWeb.Consultas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediWeb.Controllers
{
    public class ProcedimientosMedicosController : Controller
    {

        ProcedimientosMedicosConsulta ProcedimientosMedicosConsultas = new ProcedimientosMedicosConsulta();
    


        public IActionResult ListaDoctor(Int32 id)
        {
            ViewBag.Id = id;
            var enfermeraLista = ProcedimientosMedicosConsultas.Obtener(id);
            return View(enfermeraLista);
        }

        public IActionResult Guardar(Int32 id)
        {
          
            ViewBag.Id = id;
           
            return View();
        }





    }
}
