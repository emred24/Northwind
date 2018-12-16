using System.Collections.Generic;
using Northwind.Entities;

namespace Northwind.MvcWebUI.Models
{
    public class ProductViewModel
    {
        public List<Product> Product { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public List<Product> Products { get; internal set; }
    }
}