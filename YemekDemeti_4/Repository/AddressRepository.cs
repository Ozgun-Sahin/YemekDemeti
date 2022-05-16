using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YemekDemeti_4.Data;
using YemekDemeti_4.DTO;

namespace YemekDemeti_4.Repository
{
    public class AddressRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public Address GetAddressByCustomerID(int id)
        { 
            return _dbContext.Addresses.FirstOrDefault(x => x.CustomerID == id);
        }

        public Address GetAddressByDistrictID(int id)
        {
   
            return _dbContext.Addresses.FirstOrDefault(x => x.DistrictID == id);
        }

        public IEnumerable<Address> GetAllAddressByCustomerID(int id)
        {  

            return _dbContext.Addresses.Where(x => x.CustomerID == id).ToList();
        }

        public void AddAddress(AddressDTO adres)
        {
            _dbContext.Addresses.Add(new Address() 
            {
                AddressLine1 = adres.AddressLine1,
                AdressTitle=adres.AdressTitle,
                CustomerID=adres.CustomerID,
                CityID=adres.CityID,
                DistrictID=adres.CityID,

            });
        }

        public void SaveAddress()
        {
            _dbContext.SaveChanges();
        }

        //public void AddAddress(AddressDTO adres)
        //{
        //    _dbContext.Addresses.Add(new Address()
        //    {
        //        ID=adres.ID,
        //        AddressLine1=adres.AddressLine1,
        //        AdressTitle=adres.AdressTitle,
        //        CityID=adres.CityID,
        //        DistrictID=adres.DistrictID,
        //        CustomerID=adres.CustomerID
        //    });
        //}


    }
}