using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMAD.Model.DAOs.ClientOrderDao
{
    public class ClientOrderDaoEntityFramework:
        GenericDaoEntityFramework<ClientOrder, Int64>, IClientOrderDao
    {
        #region IClientOrderDao Orders

        public List<ClientOrder> getAllOrders(long clientId, int startIndex, int count)
        {
            #region Option 1: Using Linq.

            DbSet<CLientOrder> accountOperations = Context.Set<ClientOrder>();

            List<ClientOrder> result =
                (from cliOrd in clientOrder
                 where cliOrd.clientId == clientId
                 select cliOrd).Skip(startIndex).Take(count).ToList();

            #endregion Option 1: Using Linq.
        }

        public List<ClientOrder> getSpecificOrder(long orderId, int startIndex,
            int count)
        {
            #region Option 1: Using Linq.

            DbSet<ClientOrder> orders = Context.Set<ClientOrder>();

            var result =
                 (from c in clientOrder
                  where c.orderId == orderId
                  orderby c.orderId
                  select c).Skip(startIndex).Take(count).ToList();

            return result;

            #endregion Option 1: Using Linq.


        }
    }
}