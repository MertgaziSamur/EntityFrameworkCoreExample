using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.EfCore.Data.Entities
{
    public class SaleHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        //navigation property
        public Product Product { get; set; }
        public int Amount { get; set; }

    }
}
