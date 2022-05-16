using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YemekDemeti_4.Data;
using YemekDemeti_4.DTO;

namespace YemekDemeti_4.Repository
{
    public class FoodRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public Food GetFoodByID(int id)
        {
            return _dbContext.Foods.FirstOrDefault(x => x.ID == id);
        }

        public Food GetFoodByName(string name)
        {
            return _dbContext.Foods.FirstOrDefault(x => x.RestaurantSpecificName == name);
        }

        public Food GetFoodByMaxSale()
        {
            int maxSale = (int)_dbContext.Foods.Max(x => x.NumberOfSales);

            return _dbContext.Foods.Where(x => x.NumberOfSales == maxSale).FirstOrDefault();
        }

        public IEnumerable<Food> GetAllFoodsByDiscriminator(string Discriminator)
        {
            return _dbContext.Foods.Where(x => x.Discriminator == Discriminator).ToList();
        }


        public IEnumerable<Food> GetAllFoodsByRestaurantID(int id)
        {
            return _dbContext.Foods.Where(x=> x.RestaurantID == id).ToList();
        }



        public void AddFood(FoodDTO yemek, string adminName, int restoranID)
        {
            _dbContext.Foods.Add(new Food()
            {
                CategoryID = yemek.CategoryID,
                RestaurantSpecificName = yemek.RestaurantSpecificName,
                RestaurantSpecificUnicPrice = yemek.RestaurantSpecificUnicPrice,
                Discriminator = adminName,
                RestaurantID = restoranID,
                RestaurantSpecificImage = yemek.RestaurantSpecificImage,
                NumberOfSales = 0
            });
        }

        public void UpdateFood(FoodDTO food)
        {
            _dbContext.Entry(new Food()
            {
                ID = food.ID,
                CategoryID = food.CategoryID,
                RestaurantSpecificName = food.RestaurantSpecificName,
                RestaurantSpecificUnicPrice = food.RestaurantSpecificUnicPrice,
                RestaurantSpecificImage = food.RestaurantSpecificImage,
                Discriminator = food.Discriminator,
                RestaurantID = food.RestaurantID,
                NumberOfSales = 0

            }).State = EntityState.Modified;
        }

        public void FoodSave()
        {
            _dbContext.SaveChanges();
        }
    }
}