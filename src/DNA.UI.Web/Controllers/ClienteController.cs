using System;
using DNA.Application.Interfaces;
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
        [Route("cliente-management/list-all")]
        public IActionResult Index()
        {
            return View(_clienteAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("cliente-management/cliente-details/{id:guid}")]
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
        [Authorize(Policy = "CanWriteClienteData")]
        [Route("cliente-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteClienteData")]
        [Route("cliente-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);
            _clienteAppService.Register(clienteViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "CLiente Registrado com sucesso!";

            return View(clienteViewModel);
        }
        
        [HttpGet]
        [Authorize(Policy = "CanWriteClienteData")]
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
        [Authorize(Policy = "CanWriteClienteData")]
        [Route("cliente-management/edit-cliente/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            _clienteAppService.Update(clienteViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Cliente autalizado com sucesso!";

            return View(clienteViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveClienteData")]
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
        [Authorize(Policy = "CanRemoveClienteData")]
        [Route("cliente-management/remove-cliente/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remove(id);

            if (!IsValidOperation()) return View(_clienteAppService.GetById(id));

            ViewBag.Sucesso = "Cliente removido cm sucesso!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("cliente-management/cliente-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var clienteHistoryData = _clienteAppService.GetAllHistory(id);
            return Json(clienteHistoryData);
        }
    }
}
