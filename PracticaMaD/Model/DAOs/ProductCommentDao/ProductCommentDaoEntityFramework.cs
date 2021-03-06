using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao
{
    public class ProductCommentDaoEntityFramework :
        GenericDaoEntityFramework<ProductComment, Int64>, IProductCommentDao
    {
        public List<ProductComment> FindByProductId(long productId, int startIndex, int count)
        {
            DbSet<ProductComment> productComment = Context.Set<ProductComment>();
            DbSet<Tag> tag = Context.Set<Tag>();
            List<ProductComment> result =
                (from prodComm in productComment.Include("Tag")
                 where prodComm.productId == productId
                 select prodComm).OrderByDescending(prodComm => prodComm.commentDate).Skip(startIndex).Take(count).ToList();

            return result;
        }

        public bool ExistByProductIdAndClientId(long productId, long clientId)
        {
            DbSet<ProductComment> productComment = Context.Set<ProductComment>();

            ProductComment product = null;

            var result =
                 (from p in productComment
                  where p.clientId == clientId &&
                        p.productId == productId
                  select p);

            product = result.FirstOrDefault();

            if (product == null)
            {
                return false;
            }

            return true;
        }

        public ProductComment FindByProdIdAndClientId(long prodId, long clientId)
        {
            DbSet<ProductComment> productComment = Context.Set<ProductComment>();
            DbSet<Tag> tag = Context.Set<Tag>();
            var result =
                (from prodComm in productComment.Include("Tag")
                 where prodComm.productId == prodId &&
                 prodComm.clientId == clientId
                 select prodComm).ToList();
            ProductComment product = result.FirstOrDefault();

            return product;
        }

        public ProductComment FindById(long commentId)
        {
            DbSet<ProductComment> productComment = Context.Set<ProductComment>();
            DbSet<Tag> tag = Context.Set<Tag>();
            var result =
                (from prodComm in productComment.Include("Tag")
                 where prodComm.commentId == commentId
                 select prodComm).ToList();
            ProductComment product = result.FirstOrDefault();

            return product;
        }
    }
}