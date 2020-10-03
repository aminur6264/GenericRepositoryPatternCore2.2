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
    }
}
