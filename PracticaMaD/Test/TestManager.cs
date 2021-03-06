﻿using Ninject;
using System.Configuration;
using System.Data.Entity;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService;
using Es.Udc.DotNet.PracticaMad.Model.Service.ClientOrderLineService;
using Es.Udc.DotNet.PracticaMad.Model.Services.TagService;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    public class TestManager
    {
        /// <summary>
        /// Configures and populates the Ninject kernel
        /// </summary>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel()
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };

            IKernel kernel = new StandardKernel(settings);

            kernel.Bind<IClientDao>().
                To<ClientDaoEntityFramework>();

            kernel.Bind<IClientService>().
                To<ClientService>();

            kernel.Bind<ICreditCardDao>().
              To<CreditCardDaoEntityFramework>();

            kernel.Bind<ICreditCardService>().
                To<CreditCardService>();

            kernel.Bind<IClientOrderDao>().
              To<ClientOrderDaoEntityFramework>();

            kernel.Bind<IClientOrderService>().
                To<ClientOrderService>();

            kernel.Bind<ICategoryDao>().
             To<CategoryDaoEntityFramework>();

            kernel.Bind<IProductDao>().
               To<ProductDaoEntityFramework>();

            kernel.Bind<IProductService>().
                To<ProductService>();

            kernel.Bind<IShoppingCartService>().
                To<ShoppingCartService>();

            kernel.Bind<IProductCommentDao>().
               To<ProductCommentDaoEntityFramework>();

            kernel.Bind<IProductCommentService>().
                To<ProductCommentService>();

            kernel.Bind<ITagDao>().
               To<TagDaoEntityFramework>();

            kernel.Bind<ITagService>().
             To<TagService>();

            kernel.Bind<IClientOrderLineDao>().
              To<ClientOrderLineDaoEntityFramework>();

            kernel.Bind<IClientOrderLineService>().
                To<ClientOrderLineService>();

            string connectionString =
                ConfigurationManager.ConnectionStrings["practicaMADEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);

            return kernel;
        }

        /// <summary>
        /// Configures the Ninject kernel from an external module file.
        /// </summary>
        /// <param name="moduleFilename">The module filename.</param>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel(string moduleFilename)
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };
            IKernel kernel = new StandardKernel(settings);

            kernel.Load(moduleFilename);

            return kernel;
        }

        public static void ClearNInjectKernel(IKernel kernel)
        {
            kernel.Dispose();
        }
    }
}