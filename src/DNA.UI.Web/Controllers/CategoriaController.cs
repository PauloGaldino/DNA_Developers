using DNA.Application.Interfaces.Cadastro.Categorias;
using DNA.Application.ViewModels.Cadastro.Categorias;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.UI.Web.Controllers
{
    [Authorize]
    public class CategoriaController : BaseController
    {

        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _categoriaAppService = categoriaAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("categoria-management/list-all")]
        public IActionResult Index()
        {
            return View(_categoriaAppService.GetAll());
        }

      

        [HttpGet]
        [AllowAnonymous]
        [Route("categoria-management/categoria-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaViewModel = _categoriaAppService.GetById(id.Value);

            if (categoriaViewModel == null)
            {
                return NotFound();
            }

            return View(categoriaViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("categoria-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("categoria-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaViewModel);
            _categoriaAppService.Register(categoriaViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Categoria Registrada!";

            return View(categoriaViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("categoria-management/edit-categoria/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaViewModel = _categoriaAppService.GetById(id.Value);

            if (categoriaViewModel == null)
            {
                return NotFound();
            }

            return View(categoriaViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("categoria-management/edit-categoria/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaViewModel);

            _categoriaAppService.Update(categoriaViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(categoriaViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("categoria-management/remove-categoria/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaViewModel = _categoriaAppService.GetById(id.Value);

            if (categoriaViewModel == null)
            {
                return NotFound();
            }

            return View(categoriaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("categoria-management/remove-categoria/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _categoriaAppService.Remove(id);

            if (!IsValidOperation()) return View(_categoriaAppService.GetById(id));

            ViewBag.Sucesso = "Categoria Removida!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("categoria-management/categoria-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var categoriaHistoryData = _categoriaAppService.GetAllHistory(id);
            return Json(categoriaHistoryData);
        }
    }
}