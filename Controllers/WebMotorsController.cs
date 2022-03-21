using DesafioWebMotors.Models;
using DesafioWebMotors.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioWebMotors.Controllers
{
    public class WebMotorsController : Controller
    {
        private WebMotorsApiService _webapiservice;
        private MainService _mainservice;
        
        public WebMotorsController()
        {
            _mainservice = new MainService();
            _webapiservice = new WebMotorsApiService();

        }
        public IActionResult EscolherMarca()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(Anuncio anuncio)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Preencha os campos corretamente");
            }
            _mainservice.Adicionar(anuncio);
            return Redirect("/");
        }[HttpGet]
        public async Task<IActionResult> ListarMarcas()
        {
            var marcas = await _webapiservice.ListarMarcas();
            return View(marcas);
        }
        public async Task<IActionResult> ListarModelos()
        {
            var modelos = await _webapiservice.ListarModelos(1);
            return View(modelos);

        }


    }
}
