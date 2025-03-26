using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository productRepository;
        public NavController(IProductRepository productRepository)
            {
            this.productRepository = productRepository;
            }
        public ActionResult Menu(string category=null )
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = this.productRepository.GetAllCategories();
            return View(categories);
        }
    }
}