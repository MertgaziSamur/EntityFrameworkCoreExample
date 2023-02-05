using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Udemy.EfCore.Data.Contexts;
using Udemy.EfCore.Data.Entities;

namespace Udemy.EfCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            EfContext context = new();

            //var entityEntry = context.Products.Add(new Data.Entities.Product
            //{
            //    Name = "Telefon",
            //    Price = 3400
            //});

            //var updatedProduct = context.Products.Find(1);

            //updatedProduct.Price = 4500;
            //context.Products.Update(updatedProduct);

            //var deletedProduct = context.Products.FirstOrDefault(x => x.Id == 2);
            //if (deletedProduct == null)
            //{
            //    throw new Exception("Kayıt bulunamadı");
            //}
            //else
            //{
            //    context.Products.Remove(deletedProduct);
            //}
            Product product = new Product()
            {
                Name = "Bilgisayar",
                Price = 150000
            };
            context.Products.Add(product);
            context.SaveChanges();
            return View();
        }
    }
}
