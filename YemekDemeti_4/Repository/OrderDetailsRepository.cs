using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YemekDemeti_4.Data;

namespace YemekDemeti_4.Repository
{
    public class OrderDetailsRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public IEnumerable<OrderDetail>  GetAllOrderDetailByOrderID(int id)
        {
            return _dbContext.OrderDetails.Where(x => x.OrderID == id).ToList();
        }
    }
}