using DNA.Application.Interfaces.Cadastro.Common.Expedidor;
using DNA.Application.ViewModels.Cadastro.Common.Expedidores;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.UI.Web.Controllers
{
  
       [Authorize]
        public class ExpedidorController : BaseController
        {
            private readonly IExpedidorAppService _expedidorAppService;

        public ExpedidorController(IExpedidorAppService expedidorAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _expedidorAppService = expedidorAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("expedidor-management/list-all")]
        public IActionResult Index()
        {
            return View(_expedidorAppService.GetAll());
        }



        [HttpGet]
        [AllowAnonymous]
        [Route("expedidor-management/expedidor-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedidorViewModel = _expedidorAppService.GetById(id.Value);

            if (expedidorViewModel == null)
            {
                return NotFound();
            }

            return View(expedidorViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("expedidor-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("expedidor-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpedidorViewModel expedidorViewModel)
        {
            if (!ModelState.IsValid) return View(expedidorViewModel);
            _expedidorAppService.Register(expedidorViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Categoria Registrada!";

            return View(expedidorViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("expedidor-management/edit-expedidor/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedidorViewModel = _expedidorAppService.GetById(id.Value);

            if (expedidorViewModel == null)
            {
                return NotFound();
            }

            return View(expedidorViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("expedidor-management/edit-expedidor/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExpedidorViewModel expedidorViewModel)
        {
            if (!ModelState.IsValid) return View(expedidorViewModel);

            _expedidorAppService.Update(expedidorViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(expedidorViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("expedidor-management/remove-expedidor/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedidorViewModel = _expedidorAppService.GetById(id.Value);

            if (expedidorViewModel == null)
            {
                return NotFound();
            }

            return View(expedidorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("expedidor-management/remove-expedidor/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _expedidorAppService.Remove(id);

            if (!IsValidOperation()) return View(_expedidorAppService.GetById(id));

            ViewBag.Sucesso = "Categoria Removida!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("expedidor-management/expedidor-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var expedidorHistoryData = _expedidorAppService.GetAllHistory(id);
            return Json(expedidorHistoryData);
        }
    }
}