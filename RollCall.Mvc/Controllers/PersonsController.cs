using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
