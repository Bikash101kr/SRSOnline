﻿using SRSOnline.BL;
using SRSOnline.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SRSOnline
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database. 
            Database.SetInitializer(new ProductDatabaseInitializer());

            // Create the custom role and user.
            RoleActions roleactions = new RoleActions();
            roleactions.adduserandrole();

            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);
        }
        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "ProductsByCategoryRoute",
                "Category/{categoryName}",
                "~/Views/Products.aspx"
            );
            routes.MapPageRoute(
                "ProductByNameRoute",
                "Product/{productName}",
                "~/Views/ProductDetails.aspx"
            );
        }
    }

}