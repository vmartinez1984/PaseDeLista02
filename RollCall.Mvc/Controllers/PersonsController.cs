using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

namespace RollCall.Mvc.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IBusinessLayer _rollCallBl;

        public PersonsController(IBusinessLayer rollCallBl)
        {
            _rollCallBl = rollCallBl;
        }

        // GET: PersonsController
        public async Task<ActionResult> Index([FromQuery] PagerDtoIn pagerDto)
        {
            PagerDto pager;            

            pager = await _rollCallBl.Person.GetAsync(pagerDto);
            ViewBag.PagerDto = pager;

            return View(pager.List);
        }

        // GET: PersonsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            PersonDto person;

            person = await _rollCallBl.Person.GetAsync(id);

            return View(person);
        }

        // GET: PersonsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonDtoIn person)
        {
            try
            {
                await _rollCallBl.Person.AddAsync(person);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            PersonDto personDto;
            List<CodigoPostalDto> codigosPostales;

            personDto = await _rollCallBl.Person.GetAsync(id);
            //codigosPostales = await _rollCallBl.CodigosPostales.ObtenerCodigosPostales(personDto.ZipCode);
            //if(codigosPostales.Count() > 1)
            //{
            //    codigosPostales.Add(new CodigoPostalDto { Colonia = "Seleccione" });
            //}
            //ViewBag.CodigosPostales = new SelectList(codigosPostales, "Colonia","Colonia");

            return View(personDto);
        }

        // POST: PersonsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PersonDtoIn person)
        {
            try
            {
                await _rollCallBl.Person.UpdateAsync(person, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            PersonDto personDto;

            personDto = await _rollCallBl.Person.GetAsync(id);

            return View(personDto);
        }

        // POST: PersonsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PersonDtoIn person)
        {
            try
            {
                await _rollCallBl.Person.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
