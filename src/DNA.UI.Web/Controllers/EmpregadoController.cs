using DNA.Application.Interfaces.Cadastro.Pessoas.Empregados;
using DNA.Application.ViewModels.Cadastro.Pessoas.Empregados;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.UI.Web.Controllers
{ 
  [Authorize]
public class EmpregadoController : BaseController
{
    private readonly IEmpregadoAppService _empregadoAppService;

    public EmpregadoController(IEmpregadoAppService empregadoAppService,
                              INotificationHandler<DomainNotification> notifications) : base(notifications)
    {
        _empregadoAppService = empregadoAppService;
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("empregadp-management/list-all")]
    public IActionResult Index()
    {
        return View(_empregadoAppService.GetAll());
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("empregado-management/empregado-details/{id:guid}")]
    public IActionResult Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empregadoViewModel = _empregadoAppService.GetById(id.Value);

        if (empregadoViewModel == null)
        {
            return NotFound();
        }

        return View(empregadoViewModel);
    }

    [HttpGet]
    [Authorize(Policy = "CanWriteCustomerData")]
    [Route("empregado-management/register-new")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Policy = "CanWriteCustomerData")]
    [Route("empregado-management/register-new")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmpregadoViewModel empregadoViewModel)
    {
        if (!ModelState.IsValid) return View(empregadoViewModel);
        _empregadoAppService.Register(empregadoViewModel);

        if (IsValidOperation())
            ViewBag.Sucesso = "Empregado Registerado!";

        return View(empregadoViewModel);
    }

    [HttpGet]
    [Authorize(Policy = "CanWriteCustomerData")]
    [Route("empregado-management/edit-empregado/{id:guid}")]
    public IActionResult Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empregadoViewModel = _empregadoAppService.GetById(id.Value);

        if (empregadoViewModel == null)
        {
            return NotFound();
        }

        return View(empregadoViewModel);
    }

    [HttpPost]
    [Authorize(Policy = "CanWriteCustomerData")]
    [Route("empregado-management/edit-empregado/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EmpregadoViewModel empregadoViewModel)
    {
        if (!ModelState.IsValid) return View(empregadoViewModel);

        _empregadoAppService.Update(empregadoViewModel);

        if (IsValidOperation())
            ViewBag.Sucesso = "Empregado Atualizado!";

        return View(empregadoViewModel);
    }

    [HttpGet]
    [Authorize(Policy = "CanRemoveCustomerData")]
    [Route("empregado-management/remove-empregado/{id:guid}")]
    public IActionResult Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empregadoViewModel = _empregadoAppService.GetById(id.Value);

        if (empregadoViewModel == null)
        {
            return NotFound();
        }

        return View(empregadoViewModel);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize(Policy = "CanRemoveCustomerData")]
    [Route("empregado-management/remove-empregado/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(Guid id)
    {
        _empregadoAppService.Remove(id);

        if (!IsValidOperation()) return View(_empregadoAppService.GetById(id));

        ViewBag.Sucesso = "Empregado Removido!";
        return RedirectToAction("Index");
    }

    [AllowAnonymous]
    [Route("empregado-management/empregado-history/{id:guid}")]
    public JsonResult History(Guid id)
    {
        var empregadoHistoryData = _empregadoAppService.GetAllHistory(id);
        return Json(empregadoHistoryData);
    }
}
}