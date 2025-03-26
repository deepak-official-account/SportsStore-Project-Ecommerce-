using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Controllers
    {
    public class ProductController : Controller
        {


        private readonly IProductRepository repository;
        private readonly ProductDbContext context = new ProductDbContext();
        private const int limit = 3;
        public ProductController(IProductRepository repository)
            {
            this.repository = repository;
            }


        [Route("Product/GetProducts/{pageNo:int?}/{category:alpha?}")]

        //if not specifying the datatype
        //[Route("Product/GetProducts/{pageNo?}/{category?}")]  // category is optional
        public ViewResult GetProducts(string category = null, int pageNo = 1)
            {
            ProductsListViewModel model = new ProductsListViewModel
                {
                Products = repository.Products(pageNo, limit, category)
            ,
                PagingInfo = new PagingInfo
                    {
                    CurrentPage = pageNo,
                    ItemsPerPage = limit,
                    TotalItems = category == null ? context.Products.Count() : context.Products.Where(p => p.Category == category).Count()
                    },
                CurrentCategory = category,
                Categories = this.repository.GetAllCategories()
                };
            return View(model);
            }

        [Route("Product/DeleteProduct/{productId:int}")]
        public ActionResult DeleteProduct(int ProductId)
            {

            bool response = this.repository.DeleteProductById(ProductId);
            if (response)
                {
                ViewBag.message = "Product Deleted Successfully";
                }

            return RedirectToAction("AddProduct", "Product");

            }

        }
    }