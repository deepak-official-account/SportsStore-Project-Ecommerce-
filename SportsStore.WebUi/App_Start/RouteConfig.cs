using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
    {
    public static void RegisterRoutes(RouteCollection routes)
        {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//Enabling attribute Routes
        routes.MapMvcAttributeRoutes();

        //// Route for root (no category or pageNO)
        //routes.MapRoute(null, "", new
        //    {
        //    controller = "Product",
        //    action = "GetProducts",
        //    Category = (string)null,
        //    PageNo = 1
        //    });



        //// Route for page number without category
        //routes.MapRoute(null, "PageNo{PageNo}", new
        //    {
        //    controller = "Product",
        //    action = "GetProducts",
        //    Category = (string)null
        //    },
        //new
        //    {
        //    PageNo = @"\d+" // Page must be a number
        //    });

        //// Route for category without pageNo
        //routes.MapRoute(null, "Category{Category}", new { controller = "Product", action = "GetProducts", PageNo = 1 });


        //// Route for category with page number
        //routes.MapRoute(null, "Category{Category}/PageNo{PageNo}", new { controller = "Product", action = "GetProducts" }, new { PageNo = @"\d+" });


        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Product", action = "GetProducts", id = UrlParameter.Optional }
        );
        }
    }
