namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YemekDemeti_4.Data.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<YemekDemeti_4.Data.YemekDemeti_4DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(YemekDemeti_4.Data.YemekDemeti_4DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(x => x.ID,
                new Customers() { UserName = "Özgün", Password = "123", ID = 1, Image = "~/Images/Resim.jpg", GSM = "12345678" },
                new Customers() { UserName = "Damla", Password = "456", ID = 2, Image = "~/Images/Resim1.jpg", GSM = "12345678" }
                );

            context.Addresses.AddOrUpdate(x => x.ID,
                new Addresses() { CustomerID = 1, AddressLine1 = "ulaşım sitesi no: 9", AdressTitle = "Ev", CityID = 1, DistrictID = 1 },
                new Addresses() { CustomerID = 1, AddressLine1 = "üsküp caddesi no: 14", AdressTitle = "İş", CityID = 1, DistrictID = 3 },
                new Addresses() { CustomerID = 2, AddressLine1 = "ulaşım sitesi no: 9", AdressTitle = "Ev", CityID = 1, DistrictID = 1 },
                new Addresses() { CustomerID = 2, AddressLine1 = "Maltepe, Şht. Danış Tunalıgil Sk. No:3", AdressTitle = "iş", CityID = 1, DistrictID = 2 }
                );


            context.Restaurants.AddOrUpdate(x => x.ID,
                new Restaurants() { Name = "Şilan", ID = 1, DistrictID = 1, AdminName = "ŞilanAdmin", Password = "123", Score = 0 },
                new Restaurants() { Name = "Bilal Kebap", ID = 2, DistrictID = 3, AdminName = "BilalAdmin", Password = "456", Score = 0 }
                );

            context.Categories.AddOrUpdate(x => x.ID,
                new Categories() { Name = "Pide", ID = 1 },
                new Categories() { Name = "Kebap", ID = 2 },
                new Categories() { Name = "Dürüm", ID = 3 }
                );

            context.restaurantSpecificFoods.AddOrUpdate(x => x.ID,
               new RestaurantSpecificFood() { RestaurantSpecificName = "Kıymalı Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 1 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Kaşarlı Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 1 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Kuşbaşılı Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 1 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Beyti", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 1 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Adana", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 1 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Urfa", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 1 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Kıymalı Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 2 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Kaşarlı Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 2 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Kuşbaşılı Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 2 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Beyti Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 2 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Adana Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 2 },
               new RestaurantSpecificFood() { RestaurantSpecificName = "Urfa Pide", CategoryID = 1, RestaurantSpecificUnicPrice = 37, ID = 1, RestaurantID = 2 }
                );



            context.Cities.AddOrUpdate(x => x.ID,
                new Cities() { ID = 1, Name = "Ankara" },
                new Cities() { ID = 2, Name = "İstanbul" },
                new Cities() { ID = 3, Name = "İzmir" }
                );

            context.Districts.AddOrUpdate(x => x.ID,
                new Districts() { ID = 1, Name = "Batıkent", CityID = 1 },
                new Districts() { ID = 2, Name = "Kızılay", CityID = 1 },
                new Districts() { ID = 3, Name = "Çankaya", CityID = 1 }
                );


        }
    }
}
