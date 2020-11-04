using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private readonly EcommerceDbContext _db;
        private readonly ISupplierServices _supplierSevice;
        public SupplierController(ISupplierServices supplierService, EcommerceDbContext db)
        {
            _db = db;
            _supplierSevice = supplierService;
        }
        // GET: SupplierController
        public async Task<IActionResult> GetListSupplier()
        {
            var listsupplier = await _supplierSevice.GetListSupplierAdmin();
            return View(listsupplier);
            #region SX Tong Hop
            // sap xep tong hop
            //return View((from p in _db.Products
            //             join c in _db.Categories on p.CategoryId equals c.Id
            //             join s in _db.Suppliers on p.SupplierId equals s.Id
            //             where p.IsDeleted == false
            //             select new SupplierAdminViewModel
            //             {
            //                 Name = s.Name,
            //                 Email = s.Email,
            //                 Phone = s.Phone,
            //                 Address = s.Address,
            //                 ProductName = p.Name,
            //                 Price = p.Price,
            //                 CategoryName = c.Name
            //             }).OrderByDescending(s=>s.Name)
            //                .ThenBy(p=>p.Price));
            #endregion
            #region Phan Trang
            //if (page == null)
            //{
            //    page = 1;
            //}
            //int skipN = ((page.Value - 1) * 10);
            //return View((from p in _db.Products
            //             join c in _db.Categories on p.CategoryId equals c.Id
            //             join s in _db.Suppliers on p.SupplierId equals s.Id
            //             select new SupplierAdminViewModel
            //             {
            //                 Name = s.Name,
            //                 Email = s.Email,
            //                 Phone = s.Phone,
            //                 Address = s.Address,
            //                 ProductName = p.Name,
            //                 Price = p.Price,
            //                 CategoryName = c.Name
            //             })
            //             .Skip(skipN)
            //             .Take(10));
            #endregion
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
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

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierController/Edit/5
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

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierController/Delete/5
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
