﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ASPNET.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET.Controllers
{
    public class ProductController : Controller
    { 

        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
           this.repo = repo;
        }

    
    
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var Product = repo.GetProduct(id);

            return View(Product);
        }
        
        public IActionResult UpdateProduct (int id)
        {
            Product prod = repo.GetProduct(id);
            repo.UpdateProduct(prod);
            if (prod == null)
            {

                return View("Production Not Found");
            }

            return View(prod);
        }


        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);
            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }
    }
}
