using DNA.Application.Interfaces.Cadastro.Common.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Common.Fornecedores;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.Service.Api.Controllers
{
    public class FornecedorController : ApiController
    {
        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedorController(
            IFornecedorAppService fornecedorAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("fornecedor-management")]
        public IActionResult Get()
        {
            return Response(_fornecedorAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("fornecedor-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var fornecedorViewModel = _fornecedorAppService.GetById(id);

            return Response(fornecedorViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("fornecedor-management")]
        public IActionResult Post([FromBody]FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(fornecedorViewModel);
            }

            _fornecedorAppService.Register(fornecedorViewModel);

            return Response(fornecedorViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustumerData")]
        [Route("fornecedor-management")]
        public IActionResult Put([FromBody]FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(fornecedorViewModel);
            }

            _fornecedorAppService.Update(fornecedorViewModel);

            return Response(fornecedorViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustumerData")]
        [Route("fornecedor-management")]
        public IActionResult Delete(Guid id)
        {
            _fornecedorAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("fornecedor-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var fornecedorHistoryData = _fornecedorAppService.GetAllHistory(id);
            return Response(fornecedorHistoryData);
        }
    }
}