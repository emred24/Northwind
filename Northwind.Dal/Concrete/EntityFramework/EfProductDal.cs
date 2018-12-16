using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private NorthwindContext _context = new NorthwindContext();

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(p => p.ProductID == productId));
            _context.SaveChanges();
        }

        public Product Get(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == productId);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            Product productUpdate = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);

            productUpdate.ProductName = product.ProductName;
            productUpdate.CategoryID = product.CategoryID;
            productUpdate.UnitPrice = product.UnitPrice;
            //productUpdate.UnitsInStock = product.UnitsInStock;

            _context.SaveChanges();
        }
    }
}
