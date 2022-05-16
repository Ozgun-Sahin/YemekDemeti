using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YemekDemeti_4.Data;
using YemekDemeti_4.DTO;

namespace YemekDemeti_4.Repository
{
    public class RestaurantRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public IEnumerable<Restaurant> GetAllRestaurantByDistrictID(int id)
        {
            return _dbContext.Restaurants.Where(x => x.DistrictID == id).ToList();
        }

        public Restaurant GetRestaurantByID(int id)
        {
            return _dbContext.Restaurants.FirstOrDefault(x => x.ID == id);
        }

        public Restaurant GetRestaurantByAdmin(string adminName)
        {
            return _dbContext.Restaurants.FirstOrDefault(x => x.AdminName == adminName);
        }


        public void UpdateRestaurant(RestaurantDTO restoran)
        {
            _dbContext.Entry(new Restaurant()
            {
                ID = restoran.ID,
                AdminName = restoran.AdminName,
                Password = restoran.Password,
                Score = restoran.Score,
                Name = restoran.Name,
                DistrictID = restoran.DistrictID,
                Image = restoran.Image
                

            }).State = EntityState.Modified;

        }

        public void CreateRestaurant(Restaurant restoran)
        {
            _dbContext.Restaurants.Add(restoran);
        }



        public void SaveRestaurant()
        {
            _dbContext.SaveChanges();
        }



    }
}