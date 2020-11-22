using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System.Collections.Generic;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao
{
    public interface IProductDao : IGenericDao<Product, Int64>
    {
        /// <summary>
        /// Finds all products by categoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>A list of Product</returns>

        List<Product> FindByCategory(Category category);

        List<Product> FindByProductNameKeyword(String keyword);

        List<Product> FindByProductNameKeywordAndCategory(String keyword, Category category);

        Product FindByProductName(string Productname);

    }
}

