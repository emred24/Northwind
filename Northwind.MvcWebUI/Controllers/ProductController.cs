using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public int PageSize = 5;
        public ActionResult Index(int page = 1)
        {
            List<Product> products = _productService.GetAll();

            return View(new ProductViewModel
            {
                Products = products.Skip((page - 1) * PageSize).Take(5).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemPerPage = PageSize,
                    TotalItems = products.Count,
                    CurrentPage = page
                }
            });
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}