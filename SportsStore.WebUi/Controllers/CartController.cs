using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;
        
        public CartController(IProductRepository productRepository)
            {
            this.productRepository = productRepository;
            }

        public ActionResult Index(string returnUrl)
            {
            return View(new CartIndexViewModel
                {
                Cart = GetCart(),
                ReturnUrl = returnUrl
                });
            }
public ActionResult AddToCart(int productId,string returnUrl )
        {

            Product product = this.productRepository.FindByProductId(productId);

            if (product != null)
                {
                GetCart().AddItem(product, 1);
                }

return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(int productId,string returnUrl)
            {

            Product product = this.productRepository.FindByProductId(productId);
            if (product != null)
                {
                GetCart().RemoveItem(product);

                }
            return RedirectToAction("Index", new { returnUrl });
            }

        public ActionResult CheckOut()
            {
            return View(new ShippingDetails());
            }

        public ActionResult ClearCart(string returnUrl)
            {
            GetCart().ClearCart();

            return RedirectToAction("Index", new { returnUrl });
            }

        private Cart GetCart()
            {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
                {
                 cart = new Cart();
                Session["Cart"] = cart;
                }
            return cart;
            }
    }
}