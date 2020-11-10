using System;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Ecommerce.Common.Helpers;
using Ecommerce.Service.ViewModels.Admin.AddProduct;

namespace Ecommerce.Admin.Controllers
{

    public class ProductController : Controller
    {
        
        private readonly IProductSevice _productSevice;
        private readonly IManufacturerServices _manufacturerSevice;
        private readonly ISupplierServices _supplierSevice;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductSevice productService, ICategoryService categoryService, ISupplierServices supplierServices,IManufacturerServices manufacturerServices,IWebHostEnvironment hostEnvironment)
        {
            _productSevice = productService;
            _manufacturerSevice = manufacturerServices;
            _supplierSevice = supplierServices;
            _categoryService = categoryService;
            _hostEnvironment = hostEnvironment;
        }
        //GET: ProductController
        public async Task<IActionResult> GetListProduct(string order, string searchString, int page = 1, int pageSize = 3)
        {
            //if (page == null) page = 1;
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            var listproduct = await _productSevice.GetListProduct(order, searchString);
            ViewBag.NameSortParm = order;
            return View(listproduct.ToPagedList(page, pageSize));
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var DetailsProduct = await _productSevice.GetDetailsProductAdminViewModels(id);
            return View(DetailsProduct);
        }
        [HttpGet]
        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            var categoryList = await _categoryService.GetAllAsync();
            var supplierList = await _supplierSevice.GetAllAsync();
            var manufactureList = await _manufacturerSevice.GetAllAsync();
            var model = new AddProductModel()
            {
                Category = categoryList,
                Supplier = supplierList,
                Manufacturer = manufactureList
            };
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productSevice.UploadImageAsync(product);
                await _productSevice.AddAsync(product, true);
                return RedirectToAction(nameof(GetListProduct)); 
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productSevice.GetByIdAsync(id);
            var categoryList = await _categoryService.GetAllAsync();
            var supplierList = await _supplierSevice.GetAllAsync();
            var manufactureList = await _manufacturerSevice.GetAllAsync();
            if (product == null)
            {
                return RedirectToAction(nameof(Create));
            }
            var model = new AddProductModel()
            {
                Product = product,
                Category = categoryList,
                Supplier = supplierList,
                Manufacturer = manufactureList
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product,Guid id)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                var p = await _productSevice.GetByIdAsync(id);
                if (p == null)
                {
                    return View();
                }
                if(product.ImageFile != null)
                {
                    await _productSevice.UploadImageAsync(product);
                    p.ImageName = product.ImageName;
                }
                p.Name = product.Name;
                p.Price = product.Price;
                p.ShortDescription = product.ShortDescription;
                p.Description = product.Description;
                p.PublicationDate = product.PublicationDate;
                p.Keyword = product.Keyword;
                p.Sku = product.Sku;
                p.UrlName = product.UrlName;
                p.CategoryId = product.CategoryId;
                p.SupplierId = product.SupplierId;
                p.ManufacturerId = product.ManufacturerId;
                await _productSevice.UpdateAsync(p);
                return RedirectToAction(nameof(GetListProduct));
            }
            catch
            {
                return View(product);
            }
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productSevice.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image/product", product.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            await _productSevice.DeleteAsync(product, true);
            return RedirectToAction(nameof(GetListProduct));
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var imagemodel = await _productSevice.GetByIdAsync(id);


            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images/product", imagemodel.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            await _productSevice.DeleteAsync(imagemodel);
            await _productSevice.SaveChangesAsync();
            return RedirectToAction(nameof(GetListProduct));
        }
    }
}
