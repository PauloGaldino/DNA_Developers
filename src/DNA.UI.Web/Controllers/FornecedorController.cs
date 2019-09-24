using DNA.Application.Interfaces.Cadastro.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Fornecedores;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.UI.Web.Controllers
{
    [Authorize]
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedorController(IFornecedorAppService fornecedorAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("fornecedor-management/list-all")]
        public IActionResult Index()
        {
            return View(_fornecedorAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("fornecedor-management/fornecedor-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorViewModel = _fornecedorAppService.GetById(id.Value);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("fornecedor-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("fornecedor-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);
            _fornecedorAppService.Register(fornecedorViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Cliente Registerado!";

            return View(fornecedorViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("fornecedor-management/edit-fornecedor/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorViewModel = _fornecedorAppService.GetById(id.Value);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("fornecedor-management/edit-fornecedor/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            _fornecedorAppService.Update(fornecedorViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Cliente Atualizado!";

            return View(fornecedorViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("fornecedor-management/remove-fornecedor/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = _fornecedorAppService.GetById(id.Value);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("fornecedor-management/remove-fornecedor/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _fornecedorAppService.Remove(id);

            if (!IsValidOperation()) return View(_fornecedorAppService.GetById(id));

            ViewBag.Sucesso = "Fornecedor Removido!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("fornecedor-management/fornecedor-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var fornecedorHistoryData = _fornecedorAppService.GetAllHistory(id);
            return Json(fornecedorHistoryData);
        }
    }
}