using FoodBank.Core.Business.Basket;
using FoodBank.Core.Business.Company;
using FoodBank.Core.Business.DropDown;
using FoodBank.Core.Business.Listing;
using FoodBank.Core.Business.Order;
using FoodBank.Core.Business.Product;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Mail;
using Microsoft.AspNet.Identity;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FoodBank.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FoodBank.Web.App_Start.NinjectWebCommon), "Stop")]

namespace FoodBank.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAppDbContext>().To<AppDbContext>();
            kernel.Bind<IEmailService>().To<MandrillEmail>();
            kernel.Bind<IDropDownBusiness>().To<DropDownBusiness>();
            kernel.Bind<IListingBusiness>().To<ListingBusiness>();
            kernel.Bind<ICompanyBusiness>().To<CompanyBusiness>();
            kernel.Bind<IOrderBusiness>().To<OrderBusiness>();
            kernel.Bind<IProductBusiness>().To<ProductBusiness>();
            kernel.Bind<IBasketBusiness>().To<BasketBusiness>();
            kernel.Bind<IUserStore<AppUser, Guid>>().To<AppUserStore>();
            kernel.Bind<UserManager<AppUser, Guid>>().ToSelf();
        }        
    }
}
