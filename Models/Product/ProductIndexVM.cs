using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Models.Product
{
    public class ProductIndexVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int QuantityInStock { get; set; }
    }
}