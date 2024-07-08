using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediWeb.Consultas;
using MediWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediWeb.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly Cloudinary _cloudinary;
        CategoriaConsulta CategoriaConsulta = new CategoriaConsulta();
        MedicamentoConsulta MedicamentoConsultas = new MedicamentoConsulta();


        public MedicamentoController(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Lista()
        {
           
            var enfermeraLista = MedicamentoConsultas.Listar();
            return View(enfermeraLista);


        }


        public IActionResult Guardar()
        {
            CargarCategorias();
            return View();
        }




        [HttpPost]
        [Route("upload")]
        public async  Task<IActionResult> Upload(IFormFile file, MedicamentoModel model)
        {


            

            if (file == null || file.Length ==0 ) {
                return BadRequest("No se cargo archivo");

            }

            var uploadParmas = new ImageUploadParams()
                {

                File = new FileDescription(file.FileName, file.OpenReadStream()),
                AssetFolder = "MediWeb"

                };

            var uploadResult = await _cloudinary.UploadAsync(uploadParmas);

            TempData["imgUrl"]= uploadResult.SecureUri.ToString();


            model.imagen = uploadResult.SecureUri.ToString();
            model.Cantidad = 0;
            var respuesta = MedicamentoConsultas.Guardar(model);

            return RedirectToAction("Lista");

        }


        [NonAction]
        private void CargarCategorias()
        {
            var generos = CategoriaConsulta.Listar();


            //    var enfermeraLista = EnfermedadesConsultas.Listar();
            ViewBag.Categorias = new SelectList(generos, "Id", "Descripcion");

        }

    }
}
