using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternCore.Models;
using RepositoryPatternCore.Repositories;

namespace RepositoryPatternCore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var products = unitOfWork.Products.GetAll();
            return View(products);
        }

        public IActionResult NewProduct(int? id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Product product = new Product();
            if (id != null)
                product = unitOfWork.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult NewProduct(Product product)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            //Product product = new Product();
            if (product.Id != 0)
            {
                Product existProduct = unitOfWork.Products.FirstOrDefault(x => x.Id == product.Id);
                existProduct.Name = product.Name;
                existProduct.Brand = product.Brand;
                existProduct.Price = product.Price;

                unitOfWork.Products.Update(existProduct);
            }
            else
                unitOfWork.Products.Add(product);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int? id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(); 
            Product product = new Product();
            if (id != null)
                product = unitOfWork.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            if (product.Id != 0)
            {
                Product existsProduct = unitOfWork.Products.FirstOrDefault(x => x.Id == product.Id);
                unitOfWork.Products.Remove(existsProduct);
                unitOfWork.Complete();
            }
            return RedirectToAction("Index");
        }
    }
}
