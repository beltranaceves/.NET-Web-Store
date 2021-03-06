using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao
{
    public interface IProductCommentDao : IGenericDao<ProductComment, Int64>
    {
        List<ProductComment> FindByProductId(long productId, int startIndex, int count);

        bool ExistByProductIdAndClientId(long productId, long clientId);

        ProductComment FindByProdIdAndClientId(long prodId, long clientId);

        ProductComment FindById(long commentId);
    }
}