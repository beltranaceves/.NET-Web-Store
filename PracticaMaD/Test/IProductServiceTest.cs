﻿using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Transactions;
using System;
using Es.Udc.DotNet.ModelUtil.Exceptions;

using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    [TestClass]
    public class IProductServiceTest
    {
        //Variables we're going to use later

        private const String clientLogin = "login1";
        private const String clientPassword = "password";
        private const String firstName = "name";
        private const String firstSurname = "1SurName";
        private const String lastSurname = "2SurName";
        private const String clientAddress = "Calle Test";
        private const String email = "user@udc.es";
        private const String clientLanguage = "spanish";
        private const String rol = "user";

        private const long NO_CLIENID_FOUND = -1;

        private static IKernel kernel;

        private static IProductDao productDao;
        private static ICategoryDao categoryDao;

        private static IProductService productService;

        public TestContext TestContext
        { get; set; }

        #region metodos apoyo

        private static long CreateProduct(long categoryId, string productName, int stock, float price)
        {
            Product p = new Product();
            p.categoryId = categoryId;
            p.productName = productName;
            p.stock = stock;
            p.price = price;
            p.registerDate = DateTime.Now;

            productDao.Create(p);

            return p.productId;
        }

        private static long CreateCategory(string categoryName)
        {
            Category category = new Category();

            category.categoryName = categoryName;

            categoryDao.Create(category);

            return category.categoryId;
        }

        #endregion metodos apoyo

        [TestMethod()]
        public void FindProductDetailsTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;
                // Create a product
                long productId = CreateProduct(categoryId, productName, stock, price);

                ProductDetails productDetails = productService.FindProductDetails(productId);

                Assert.AreEqual(productDetails.CategoryId, categoryId);
                Assert.AreEqual(productDetails.ProductName, productName);
                Assert.AreEqual(productDetails.Stock, stock);
                Assert.AreEqual(productDetails.Price, price);

                productDao.Remove(productId);
                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindProductDetailsInstanceNotFoundTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                long productId = (long)1;
                ProductDetails productDetails = productService.FindProductDetails(productId);
            }
        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;
                // Create a product
                long productId = CreateProduct(categoryId, productName, stock, price);

                ProductDetails p = new ProductDetails(productName, price, DateTime.Now, stock + 12, categoryId);

                productService.UpdateProduct(productId, p);

                ProductDetails productDetails = productService.FindProductDetails(productId);

                Assert.AreEqual(productDetails.Stock, stock + 12);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void UpdateProductInstanceNotFoundExceptionTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;
                // Create a product
                long productId = 2;

                ProductDetails p = new ProductDetails(productName, price, DateTime.Now, stock + 12, categoryId);

                productService.UpdateProduct(productId, p);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        public void FindProductByProductNameKeywordTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;
                // Create a product
                long productId = CreateProduct(categoryId, productName, stock, price);

                ProductBlock products = productService.FindProductByProductNameKeyword("Avatar", 0, 5);

                Assert.AreEqual(products.Product[0].categoryId, categoryId);
                Assert.AreEqual(products.Product[0].productName, productName);
                Assert.AreEqual(products.Product[0].stock, stock);
                Assert.AreEqual(products.Product[0].price, price);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        public void FindProductByProductNameKeywordAndCategoryTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                long categoryId2 = CreateCategory("Comics");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;
                // Create a product
                long productId = CreateProduct(categoryId, productName, stock, price);

                long productId2 = CreateProduct(categoryId2, productName, stock + 2, price);

                List<ProductDetails> products = productService.FindProductByProductNameKeywordAndCategory("Avatar", categoryId);

                Assert.AreEqual(products[0].CategoryId, categoryId);
                Assert.AreEqual(products[0].ProductName, productName);
                Assert.AreEqual(products[0].Stock, stock);
                Assert.AreEqual(products[0].Price, price);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        public void FindProductByCategoryTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                long categoryId2 = CreateCategory("Comics");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;
                // Create a product
                long productId = CreateProduct(categoryId, productName, stock, price);

                long productId2 = CreateProduct(categoryId2, productName, stock + 2, price);

                List<ProductDetails> products = productService.FindProductByCategory(categoryId);

                Assert.AreEqual(products[0].CategoryId, categoryId);
                Assert.AreEqual(products[0].ProductName, productName);
                Assert.AreEqual(products[0].Stock, stock);
                Assert.AreEqual(products[0].Price, price);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            productDao = kernel.Get<IProductDao>();
            categoryDao = kernel.Get<ICategoryDao>();

            productService = kernel.Get<IProductService>();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }

        #endregion Additional test attributes
    }
}