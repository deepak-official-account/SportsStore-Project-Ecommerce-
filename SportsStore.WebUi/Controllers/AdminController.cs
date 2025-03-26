using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
    {
    public class AdminController : Controller
        {
        private readonly IProductRepository _productRepository;
        private static readonly CloudinaryService _cloudinaryService = new CloudinaryService();
        private readonly string[] validContentTypes = { "image/jpeg", "image/png", "image/jpg" };

        public AdminController(IProductRepository productRepository)
            {
            this._productRepository = productRepository;
            }

        // Get method to display the Add Product page

        [Route ("Admin/AddProduct")]
        public ActionResult AddProduct()
            {
            return View();
            }

        [HttpPost]
        [Route("Admin/AddProduct")]
        public ActionResult AddProduct(Product product, HttpPostedFileBase ImageFile)
            {

            if (ModelState.IsValid)
                {
   
                if (ImageFile != null && ImageFile.ContentLength > 0 && IsValidFileType(ImageFile) )
                    {
                    //var responseData = _cloudinaryService.UploadImage(ImageFile.InputStream, ImageFile.FileName);
                    //product.ImagePublicId = responseData.PublicId.ToString();
                    //product.ImageUrl = responseData.Url.ToString();

                    this._productRepository.CreateProduct(product,ImageFile.InputStream,ImageFile.FileName);
                    return RedirectToAction("GetProducts", "Product");
                    }
                else
                    {
                    ViewBag.Message = "Image Format Not Supported";

                    }

                
                }
            
            return View("AddProduct");
            }

        private bool IsValidFileType(HttpPostedFileBase ImageFile)
            {
           
            return validContentTypes.Contains(ImageFile.ContentType.ToLower());
            }

        }
    }
