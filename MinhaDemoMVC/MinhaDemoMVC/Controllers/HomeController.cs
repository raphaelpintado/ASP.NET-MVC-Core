using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC.Data;
using MinhaDemoMVC.Models;

namespace MinhaDemoMVC.Controllers
{
    //[Route("")]
    //[Route("gestao-clientes")]
    public class HomeController : Controller
    {
        //[Route("")]
        //[Route("pagina-inicial")]
        //[Route("pagina-inicial/{id:int}/{categoria:guid}")]
        //public IActionResult Index(int id, Guid categoria)
        //{
        //    return View();
        //}

        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            var pedido = _pedidoRepository.ObterPedido();

            return View();
        }

        //[Route("privacidade")]
        //[Route("politica-de-privacidade")]
        public IActionResult Privacy()
        {
            //return View();
            //return Json("{'nome':'Raphael'}");
            //var fileBytes = System.IO.File.ReadAllBytes(@"C:\Arquivo.txt");
            //var fileName = "Ola.txt";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //[Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
