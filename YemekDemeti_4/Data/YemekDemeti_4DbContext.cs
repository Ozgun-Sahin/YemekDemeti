using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using YemekDemeti_4.Data.Entities;

namespace YemekDemeti_4.Data
{
    public class YemekDemeti_4DbContext :DbContext
    {
        public YemekDemeti_4DbContext()
        {
            Database.Connection.ConnectionString = "server =.; database = YemekDemeti_4Db; trusted_connection = true";
        }

        public DbSet<Foods> Foods { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<RestaurantSpecificFood> restaurantSpecificFoods { get; set; }

    }
}