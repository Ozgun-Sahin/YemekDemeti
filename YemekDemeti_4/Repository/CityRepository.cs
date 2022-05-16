using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekDemeti_4.Data;

namespace YemekDemeti_4.Repository
{
    public class CityRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public IEnumerable<City> GetAllCity()
        {
            return _dbContext.Cities.ToList();
        }
    }
}