using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.EfCore.Data.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
