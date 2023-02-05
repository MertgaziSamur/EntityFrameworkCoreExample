using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Udemy.EfCore.Data.Entities
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
