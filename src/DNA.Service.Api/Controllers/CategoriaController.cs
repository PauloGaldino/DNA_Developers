using DNA.Application.Interfaces.Cadastro.Producao.Produtos;
using DNA.Application.ViewModels.Cadastro.Producao.Produtos;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.Service.Api.Controllers
{
    [Authorize]
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(
            ICategoriaAppService categoriaAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoriaAppService = categoriaAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("categoria-management")]
        public IActionResult Get()
        {
            return Response(_categoriaAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("categoria-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var categoriaViewModel = _categoriaAppService.GetById(id);

            return Response(categoriaViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCategoriaData")]
        [Route("categoria-management")]
        public IActionResult Post([FromBody]CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoriaViewModel);
            }

            _categoriaAppService.Register(categoriaViewModel);

            return Response(categoriaViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCategoriaData")]
        [Route("categoria-management")]
        public IActionResult Put([FromBody]CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoriaViewModel);
            }

            _categoriaAppService.Update(categoriaViewModel);

            return Response(categoriaViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCategoriaData")]
        [Route("categoria-management")]
        public IActionResult Delete(Guid id)
        {
            _categoriaAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("categoria-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var categoriaHistoryData = _categoriaAppService.GetAllHistory(id);
            return Response(categoriaHistoryData);
        }
    }
}