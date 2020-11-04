using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Admin.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerServices _manufacturerSevice;
        public ManufacturerController(IManufacturerServices manufacturerService)
        {
            _manufacturerSevice = manufacturerService;
        }
        // GET: ManufacturerController
        public async Task<IActionResult> GetListManufacturer()
        {
            var listmanufacturer = await _manufacturerSevice.GetListManufacturerAdmin();
            return View(listmanufacturer);
        }

        // GET: ManufacturerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManufacturerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ManufacturerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManufacturerController/Edit/5
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

        // GET: ManufacturerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManufacturerController/Delete/5
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
