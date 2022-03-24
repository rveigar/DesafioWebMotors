using DesafioWebMotors.Models;
using DesafioWebMotors.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> ListarVeiculos()
        {
            var veiculo = await _webapiservice.ListarVeiculos();
            return View(veiculo);
        }
        public IActionResult ListarAnuncios()
        {
            var listaAnuncios = _mainservice.ListarAnuncios();

            return View(listaAnuncios);
        }
        [Route("WebMotors/ExcluirAnuncio/{id}")]
        public IActionResult ExcluirAnuncio([FromRoute] int id)
        {
            _mainservice.ExcluirAnuncio(id);
            return Redirect("/");
        }
        [HttpPost]
        [Route("WebMotors/AtualizarAnuncio/{id}")]
        public IActionResult AtualizarAnuncio([FromRoute] int id, Anuncio anuncio)
        {
              _mainservice.AtualizarAnuncio(anuncio  ,id);
              return Redirect("/");
        }
        public IActionResult EditarAnuncio([FromRoute] int id)
        {
            var resultado = _mainservice.SelecionarAnuncio(id);
            return View(resultado);
        }
        
        

    }
}
