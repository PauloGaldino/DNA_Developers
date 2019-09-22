using DNA.Application.Interfaces.Cadastro.Pessoas.Clientes;
using DNA.Application.ViewModels;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.Service.Api.Controllers
{
    [Authorize]
    public class ClienteController : ApiController
    {

        private readonly IClienteAppService _clienteAppService;

        public ClienteController(
            IClienteAppService clienteAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("cliente-management")]
        public IActionResult Get()
        {
            return Response(_clienteAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("cliente-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var clienteViewModel = _clienteAppService.GetById(id);

            return Response(clienteViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("cliente-management")]
        public IActionResult Post([FromBody]ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(clienteViewModel);
            }

            _clienteAppService.Register(clienteViewModel);

            return Response(clienteViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("cliente-management")]
        public IActionResult Put([FromBody]ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(clienteViewModel);
            }

            _clienteAppService.Update(clienteViewModel);

            return Response(clienteViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustumerData")]
        [Route("cliente-management")]
        public IActionResult Delete(Guid id)
        {
            _clienteAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("cliente-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var clienteHistoryData = _clienteAppService.GetAllHistory(id);
            return Response(clienteHistoryData);
        }
    }
}
