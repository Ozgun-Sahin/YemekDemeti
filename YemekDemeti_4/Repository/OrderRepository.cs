using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YemekDemeti_4.Data;
using YemekDemeti_4.Models;

namespace YemekDemeti_4.Repository
{
    public class OrderRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public IEnumerable<Order> GetAllOrderByCustomerID(int id)
        {
            return _dbContext.Orders.Where(x => x.CustomerID == id).ToList();
        }

        public IEnumerable<Order> GetAllOrderByRestaurantID(int id)
        {
            return _dbContext.Orders.Where(x => x.RestaurantID == id).ToList();
        }

        public Order GetOrderByID(int id)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.ID == id);
        }

        public void AddOrder(int kullaniciID, string restoran, int restoranID, int adresID)
        {
            var yeniSiparis = _dbContext.Orders.Add(new Order()
            {
                CustomerID= kullaniciID,
                RestaurantName = restoran,
                RestaurantID = restoranID,
                AddressID = adresID,
                OrderTime = DateTime.Now,
                Confirmed = false
            });

        }

        public void OrderConfirm(int id)
        {
            Order siparis = _dbContext.Orders.FirstOrDefault(x => x.ID == id);

            siparis.Confirmed = true;
        }

        public void OrderDeliver(int id)
        {
            Order siparis = _dbContext.Orders.FirstOrDefault(x => x.ID == id);

            siparis.Delivered = true;
        }

        public void OrderSave()
        {
            _dbContext.SaveChanges();
        }
    }
}