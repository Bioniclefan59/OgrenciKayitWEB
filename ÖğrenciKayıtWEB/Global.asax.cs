﻿using OgrenciBilgiKayitWEB.OkulDBContext;
using ÖğrenciKayıtWEB.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ÖğrenciKayıtWEB
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OkulDBCntxt>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OkulDBCntxt, Configuration>());
            using (var dbContext = new OkulDBCntxt())
            {
                dbContext.BolumleriDoldur();
                dbContext.OrnekDersleDoldur();
            }
        }
    }
}