using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekDemeti_4.Data;
using YemekDemeti_4.Models;
using YemekDemeti_4.Repository;

namespace YemekDemeti_4.Controllers
{
    public class HomeController : Controller
    {
        CustomerRepository CustomerRepository = new CustomerRepository();
        AddressRepository AddressRepository = new AddressRepository();
        OrderRepository OrderRepository = new OrderRepository();
        RestaurantRepository RestaurantRepository = new RestaurantRepository();

        // GET: Home
        public ActionResult Index(int? id)
        {
            
            if (Session["user"]==null)
            {
                return View();
            }
            else
            {
                if (id != null)
                {
                    ViewBag.Restaurant = RestaurantRepository.GetAllRestaurantByDistrictID((int)id);

                    Address seciliAdres = AddressRepository.GetAddressByDistrictID((int)id);

                    Session["adres"] = seciliAdres;
                }

                if (Session["user"] != null)
                {
                    ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                    string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                    Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

                    ViewBag.KullaniciID = girisYapanKullanici.ID;

                    ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

                }

                ViewBag.Count = Session["count"];

                ViewBag.Kullanici = Session["user"];

                return View();
            } 
        }
    }
}