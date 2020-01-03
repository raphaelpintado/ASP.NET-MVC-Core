using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;
using System.Net;
using KissLog;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            _logger.Trace("Usuário acessou a Home!");
            return View();
        }

        public IActionResult Privacy()
        {
            throw new System.Exception("Erro!");
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            try
            {
                throw new System.Exception("Algo horrível ocorreu!");
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }

        [ClaimsAuthorize("Produtos", "Ler")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            switch (id)
            {
                case (int)HttpStatusCode.InternalServerError:
                    modelErro.Mensagem = "Erro interno no servidor! Tente novamente mais tarde ou contate nosso suporte";
                    modelErro.Titulo = "Ocorreu um erro!";
                    modelErro.ErrorCode = id;
                    break;

                case (int)HttpStatusCode.NotFound:
                    modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com o nosso suporte.";
                    modelErro.Titulo = "Ops! Página não encontrada.";
                    modelErro.ErrorCode = id;
                    break;

                case (int)HttpStatusCode.Forbidden:
                    modelErro.Mensagem = "Você não tem permissão para fazer isso.";
                    modelErro.Titulo = "Acesso Negado";
                    modelErro.ErrorCode = id;
                    break;
            }

            return View(modelErro);
        }
    }
}
