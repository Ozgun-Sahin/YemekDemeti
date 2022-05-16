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
    public class CartController : Controller
    {
        CustomerRepository CustomerRepository = new CustomerRepository();
        AddressRepository AddressRepository = new AddressRepository();
        FoodRepository FoodRepository = new FoodRepository();
        RestaurantRepository restaurantRepository = new RestaurantRepository();
        OrderRepository OrderRepository = new OrderRepository();
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        // GET: Cart
        public ActionResult Cart()
        {
            

            if (Session["user"] != null)
            {
                ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;
            }

            ViewBag.Cart = Session["cart"];

            ViewBag.Count = Session["count"];

            string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

            ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

            ViewBag.AdresListesi = _dbContext.Addresses.Select(x => new SelectListItem()
            {
                Text = x.AdressTitle,
                Value = x.ID.ToString()

            }).ToList();

            ViewBag.Kullanici = Session["user"];

            return View();
        }

        public ActionResult Add(int? id)
        {
            

            Food eklenecekYemek = FoodRepository.GetFoodByID((int)id);

            int restoranID = (int)eklenecekYemek.RestaurantID;

            string rID = Convert.ToString(restoranID);

            Restaurant restaurant = restaurantRepository.GetRestaurantByID(restoranID);

            Session["restaurant"] = restaurant;

            if (Session["cart"]==null)
            {
                List<Food> sepet = new List<Food>();

                sepet.Add(eklenecekYemek);

                Session["cart"] = sepet;

                ViewBag.Count = sepet.Count();

                Session["count"] = 1;
            }
            else
            {
                List<Food> sepet = (List<Food>)Session["cart"];

                sepet.Add(eklenecekYemek);

                Session["cart"] = sepet;

                ViewBag.Count = sepet.Count();

                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }

            return Redirect("/Restaurant/Menu/" + rID);
        }

        public ActionResult Remove(int? id)
        {
            

            List<Food> sepet = (List<Food>)Session["cart"];

            Food cikarilanYemek = FoodRepository.GetFoodByID((int)id);

            sepet.RemoveAt((int)id);

            Session["cart"] = sepet;

            Session["count"] = Convert.ToInt32(Session["count"]) - 1;

            return Redirect("/Cart/Cart");
        }

        [HttpPost]
        public ActionResult CheckOut(AddressVM vm)
        {
            

            string userName = ((CustomerVM)Session["user"]).UserName;

            string restaurantName = ((Restaurant)Session["restaurant"]).Name;

            int restaurantID = ((Restaurant)Session["restaurant"]).ID;

            Customer user = CustomerRepository.GetCustomerByUserName(userName);

            int userID = user.ID;

            List<Food> cart = (List<Food>)Session["cart"];

            var cartList = new List<string>();

            foreach (var item in cart)
            {
                cartList.Add(item.RestaurantSpecificName);
            }

            var newOrder = _dbContext.Orders.Add(new Order()
            {
                CustomerID = userID,
                OrderTime = DateTime.Now,
                RestaurantName = restaurantName,
                RestaurantID = restaurantID,
                Confirmed = false,
                AddressID = vm.ID
            });

            _dbContext.SaveChanges();

            int orderID = newOrder.ID;

            var duplicates = from d in cartList group d by d into c let count = c.Count() orderby count descending select new { Value = c.Key, Count = count };

            foreach (var v in duplicates)
            {
                string strValue = v.Value;

                int Count = v.Count;

                Food food = FoodRepository.GetFoodByName(strValue);

                if (food.NumberOfSales==null)
                {
                    food.NumberOfSales = 0;
                }

                food.NumberOfSales = food.NumberOfSales + Count;

                FoodRepository.FoodSave();


                _dbContext.OrderDetails.Add(new OrderDetail()
                {
                    OrderID = orderID,
                    FoodID = food.ID,
                    UnitPrice = (decimal)food.RestaurantSpecificUnicPrice,
                    Quantity = Count
                });

                _dbContext.SaveChanges();
            }


            Session["cart"] = null;

            Session["count"] = null;

            return Redirect("/Home/Index");
        }

    }
}