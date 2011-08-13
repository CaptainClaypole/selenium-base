using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using auctionbaseUI.Models;
using Ninject;
using Ninject.Modules;

namespace auctionbaseUI {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : Ninject.Web.Mvc.NinjectHttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected override void OnApplicationStarted() {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        //protected void Application_Start() {
        //    AreaRegistration.RegisterAllAreas();

        //    RegisterGlobalFilters(GlobalFilters.Filters);
        //    RegisterRoutes(RouteTable.Routes);
        //}

        static IKernel _container;
        public static IKernel Container {
            get {
                if (_container == null) {
                    _container = new StandardKernel(new SiteModule());
                }
                return _container;
            }
        }
        protected override IKernel CreateKernel() {
            return Container;
        }


        internal class SiteModule : NinjectModule {
            public override void Load() {
                Bind<ObjectContext>().To<seleniumScrapeEntities>().InRequestScope();
                //Bind<IMusicRepo>().To<MusicRepo>().InRequestScope();
                //Bind<IShoppingCart>().To<ShoppingCart>().InRequestScope();
            }
        }
    }
}