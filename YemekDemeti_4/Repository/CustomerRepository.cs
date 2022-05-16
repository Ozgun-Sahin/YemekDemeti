using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekDemeti_4.Data;
using YemekDemeti_4.DTO;
using YemekDemeti_4.Models;

namespace YemekDemeti_4.Repository
{
    public class CustomerRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public Customer GetCustomerByUserName(string name)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.UserName == name);
        }

        public Customer GetCustomerByID(int id)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateCustomer(CustomerDTO kullanici)
        {

            //_dbContext.Entry(kullanici).State = EntityState.Modified;

            _dbContext.Entry(new Customer()
            {
                ID = kullanici.ID,
                UserName = kullanici.UserName,
                Password = kullanici.Password,
                Image = kullanici.Image,
                GSM= kullanici.GSM,

            }).State = EntityState.Modified;

        }

        
        public void CreateCustomer(CustomerDTO kullanici)
        {

            _dbContext.Customers.Add(new Customer()
            {
                UserName = kullanici.UserName,
                Password = kullanici.Password,
                Image = kullanici.Image,
                GSM = kullanici.GSM

            });

        }


        public void SaveCustomer()
        {
            _dbContext.SaveChanges();
        }

       


    }
}