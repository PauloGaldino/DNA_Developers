using DNA.Application.Interfaces.Cadastro.Common.Expedidor;
using DNA.Application.ViewModels.Cadastro.Common.Expedidores;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.Service.Api.Controllers
{
    public class ExpedidorController : ApiController
    {
        private readonly IExpedidorAppService _expedidorAppService;

        public ExpedidorController(
            IExpedidorAppService expedidorAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _expedidorAppService = expedidorAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("expedidor-management")]
        public IActionResult Get()
        {
            return Response(_expedidorAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("expedidor-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var fornecedorViewModel = _expedidorAppService.GetById(id);

            return Response(fornecedorViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("expedidor-management")]
        public IActionResult Post([FromBody]ExpedidorViewModel expedidordorViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(expedidordorViewModel);
            }

            _expedidorAppService.Register(expedidordorViewModel);

            return Response(expedidordorViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("expedidor-management")]
        public IActionResult Put([FromBody]ExpedidorViewModel expedidorViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(expedidorViewModel);
            }

            _expedidorAppService.Update(expedidorViewModel);

            return Response(expedidorViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustumerData")]
        [Route("expedidor-management")]
        public IActionResult Delete(Guid id)
        {
            _expedidorAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("expedidor-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var expedidorHistoryData = _expedidorAppService.GetAllHistory(id);
            return Response(expedidorHistoryData);
        }
    }
}