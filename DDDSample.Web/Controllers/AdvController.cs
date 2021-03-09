using System;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDDSample.Web.Controllers
{
    [Route("Adv")]
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
        [Route("")]
        [Route("/")]
        [Route("adv-management/list-all")]
        public IActionResult Index()
        {
            return View(_advAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("adv-management/adv-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _advAppService.GetById(id.Value);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        [Route("adv-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("adv-management/register-new")]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(AdvViewModel advViewModel)
        {
            if (!ModelState.IsValid) return View(advViewModel);
            _advAppService.Register(advViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Anúncio Registrado com sucesso!";

            return View(advViewModel);
        }

        [HttpGet]
        [Route("adv-management/register-new-vehicle", Name ="cria_anuncio")]
        public IActionResult Create(VeiculoViewModel veiculoModel )
        {
            var model = new AdvViewModel();
            model.Ano = Convert.ToInt32( veiculoModel.YearFab);
            model.Marca = veiculoModel.Make;
            model.Modelo = veiculoModel.Model;
            model.Quilometragem = Convert.ToInt32(veiculoModel.KM);
            model.Versao = veiculoModel.Version;
            
            return View(model);
        }

        [HttpGet]
        [Route("adv-management/edit-adv/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advViewModel = _advAppService.GetById(id.Value);

            if (advViewModel == null)
            {
                return NotFound();
            }

            return View(advViewModel);
        }

        [HttpPost]
        [Route("adv-management/edit-adv/{id:int}")]
        public IActionResult Edit(AdvViewModel advViewModel)
        {
            if (!ModelState.IsValid) return View(advViewModel);

            _advAppService.Update(advViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Anúncio Atualizado!";

            return View(advViewModel);
        }

        [HttpGet]
        [Route("adv-management/remove-adv/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advViewModel = _advAppService.GetById(id.Value);

            if (advViewModel == null)
            {
                return NotFound();
            }

            return View(advViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("adv-management/remove-adv/{id:int}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _advAppService.Remove(id);

            if (!IsValidOperation()) return View(_advAppService.GetById(id));

            ViewBag.Sucesso = "Anúncio removido!";
            return RedirectToAction("Index");
        }

        

        [AllowAnonymous]
        [Route("adv-management/adv-history/{id:Guid" +
            "" +
            "}")]
        public JsonResult History(Guid id)
        {
            var advHistoryData = _advAppService.GetAllHistory(id);
            return Json(advHistoryData);
        }
    }
}
