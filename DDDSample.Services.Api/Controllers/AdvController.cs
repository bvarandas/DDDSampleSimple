using System;
using System.Collections.Generic;
using System.Linq;
using DDDSample.Application.Interfaces;
using DDDSample.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using DDDSample.Application.ViewModels;

namespace DDDSample.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvController : BaseController
    {
        private readonly IAdvAppService _advAppService;

        public AdvController(IAdvAppService advAppService, 
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _advAppService = advAppService;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("adv-management/list-all")]
        public IActionResult GetAll()
        {
            return Response(_advAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("adv-management/adv-detail/{Id:int}")]
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var advViewModel = _advAppService.GetById(Id.Value);

            if (advViewModel == null)
            {
                return NotFound();
            }

            return Response(advViewModel);
        }

        /// <summary>
        /// Insere um anuncio
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("adv-management/")]
        public IActionResult Create(AdvViewModel model)
        {
            if (!ModelState.IsValid) return Response(model);
            _advAppService.Register(model);

            /*
            if (IsValidOperation())
                ViewBag.Sucesso = "Anúncio Registrado!";*/

            return Response(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("adv-management/{id:int}")]
        public IActionResult Edit(AdvViewModel model)
        {
            if (!ModelState.IsValid) return Response(model);

            _advAppService.Update(model);
            /*
            if (IsValidOperation())
                ViewBag.Sucesso = "Anúncio atualizado!";*/

            return Response(model);
        }

        [HttpDelete]
        [Route("adv-management/{id:int}")]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var model = _advAppService.GetById(Id.Value);

            if (model == null)
            {
                return NotFound();
            }

            return Response(model);
        }

    }
}