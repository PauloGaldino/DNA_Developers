using DNA.Application.Interfaces.Cadastro.Pessoas.Empregados;
using DNA.Application.ViewModels.Cadastro.Pessoas.Empregados;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.Service.Api.Controllers
{
    [Authorize]
    public class EmpregadoController : ApiController
    {

        private readonly IEmpregadoAppService _empregadoAppService;

        public EmpregadoController(
            IEmpregadoAppService empregadoAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _empregadoAppService = empregadoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("empregado-management")]
        public IActionResult Get()
        {
            return Response(_empregadoAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("empregado-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var empregadoViewModel = _empregadoAppService.GetById(id);

            return Response(empregadoViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("empregado-management")]
        public IActionResult Post([FromBody]EmpregadoViewModel empregadoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(empregadoViewModel);
            }

            _empregadoAppService.Register(empregadoViewModel);

            return Response(empregadoViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("empregado-management")]
        public IActionResult Put([FromBody]EmpregadoViewModel empregadoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(empregadoViewModel);
            }

            _empregadoAppService.Update(empregadoViewModel);

            return Response(empregadoViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustumerData")]
        [Route("empregado-management")]
        public IActionResult Delete(Guid id)
        {
            _empregadoAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("empregado-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var empregadoHistoryData = _empregadoAppService.GetAllHistory(id);
            return Response(empregadoHistoryData);
        }
    }
}

