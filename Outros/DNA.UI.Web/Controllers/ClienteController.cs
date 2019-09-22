using System;
using DNA.Application.Interfaces.Cadastro.Pessoas.Clientes;
using DNA.Application.ViewModels;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNA.UI.Web.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/list-all")]
        public IActionResult Index()
        {
            return View(_clienteAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/customer-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = _clienteAppService.GetById(id.Value);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);
            _clienteAppService.Register(clienteViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Registered!";

            return View(clienteViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = _clienteAppService.GetById(id.Value);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            _clienteAppService.Update(clienteViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(clienteViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveCustumerData")]
        [Route("cliente-management/remove-cliente/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = _clienteAppService.GetById(id.Value);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustumerData")]
        [Route("cliente-management/remove-cliente/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remove(id);

            if (!IsValidOperation()) return View(_clienteAppService.GetById(id));

            ViewBag.Sucesso = "Customer Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("custumer-management/cliente-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var clienteHistoryData = _clienteAppService.GetAllHistory(id);
            return Json(clienteHistoryData);
        }
    }
}
