using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekDemeti_4.Data;
using YemekDemeti_4.Data.Entities;
using YemekDemeti_4.DTO;
using YemekDemeti_4.Models;
using YemekDemeti_4.Repository;

namespace YemekDemeti_4.Controllers
{
    public class RestaurantController : Controller
    {
        CustomerRepository CustomerRepository = new CustomerRepository();
        AddressRepository AddressRepository = new AddressRepository();
        OrderRepository OrderRepository = new OrderRepository();
        CityRepository CityRepository = new CityRepository();
        CommentRepository CommentRepository = new CommentRepository();
        RestaurantRepository RestaurantRepository = new RestaurantRepository();
        OrderDetailsRepository OrderDetailsRepository = new OrderDetailsRepository();
        FoodRepository foodRepository = new FoodRepository();
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        // GET: Restaurant

        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(RestaurantVM vm)
        {

            if (ModelState.IsValid)
            {
                Restaurant restoranAdmin = RestaurantRepository.GetRestaurantByAdmin(vm.AdminName);

                if (restoranAdmin != null)
                {
                    if (restoranAdmin.Password == vm.Password)
                    {
                        Session["admin"] = vm;
                        return Redirect("/Restaurant/AdminPage");
                    }
                    else
                    {
                        ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı";
                    }

                    return View(vm);
                }
                else
                {
                    ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı";
                }

            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();

            return Redirect("/Home/Index");
        }

        public ActionResult Menu(int? id)
        {
            if (Session["restaurant"] != null)
            {
                int restorantID = ((Restaurant)Session["restaurant"]).ID;

                if (restorantID != id)
                {
                    return View("HataSayfası");
                }
            }

            Restaurant restoran = RestaurantRepository.GetRestaurantByID((int)id);

            string adminName = restoran.AdminName;

            //ViewBag.Menu = foodRepository.GetAllFoodsByDiscriminator(adminName);

            ViewBag.Menu = foodRepository.GetAllFoodsByRestaurantID((int)id);

            if (Session["user"] != null)
            {
                ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

                ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

            }

            ViewBag.Count = Session["count"];

            ViewBag.Yorumlar = CommentRepository.GetAllCommentByRestaurantID((int)id);

            ViewBag.YroumSayısı = ((List<Comment>)CommentRepository.GetAllCommentByRestaurantID((int)id)).Count(); // bunu nerde kullandım hatırlamıyorum ??

            ViewBag.Kullanici = Session["user"];

            return View();
        }

        [AdminAuthorization(Role = "admin")]





        public ActionResult AdminPage()
        {
            ViewBag.Admin = ((RestaurantVM)Session["admin"]).AdminName;

            string adminName = ((RestaurantVM)Session["admin"]).AdminName;

            Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

            ViewBag.RestoranIsmi = girisYapanAdmin.Name;

            ViewBag.RestoranPuanı = girisYapanAdmin.Score;

            ViewBag.RestoranResmi = girisYapanAdmin.Image;

            Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

            ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

            ViewBag.Siparisler = OrderRepository.GetAllOrderByRestaurantID(girisYapanAdmin.ID);

            ViewBag.Yorumlar = CommentRepository.GetAllCommentByRestaurantID(girisYapanAdmin.ID);

            return View();
        }

        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminMenu()
        {
            ViewBag.Admin = ((RestaurantVM)Session["admin"]).AdminName;

            string adminName = ((RestaurantVM)Session["admin"]).AdminName;

            Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

            ViewBag.RestoranIsmi = girisYapanAdmin.Name;

            ViewBag.RestoranPuanı = girisYapanAdmin.Score;

            ViewBag.RestoranResmi = girisYapanAdmin.Image;

            Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

            ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

            ViewBag.Siparisler = OrderRepository.GetAllOrderByRestaurantID(girisYapanAdmin.ID);

            ViewBag.Yorumlar = CommentRepository.GetAllCommentByRestaurantID(girisYapanAdmin.ID);

            ViewBag.Menu = foodRepository.GetAllFoodsByDiscriminator(adminName);

            return View();
        }


        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminComment()
        {
            ViewBag.Admin = ((RestaurantVM)Session["admin"]).AdminName;

            string adminName = ((RestaurantVM)Session["admin"]).AdminName;

            Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

            ViewBag.RestoranIsmi = girisYapanAdmin.Name;

            Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

            ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

            ViewBag.RestoranPuanı = girisYapanAdmin.Score;

            ViewBag.RestoranResmi = girisYapanAdmin.Image;

            ViewBag.Yorumlar = CommentRepository.GetAllCommentByRestaurantID(girisYapanAdmin.ID);

            ViewBag.Siparisler = OrderRepository.GetAllOrderByRestaurantID(girisYapanAdmin.ID);

            return View();
        }


        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminOrder()
        {
            ViewBag.Admin = ((RestaurantVM)Session["admin"]).AdminName;

            string adminName = ((RestaurantVM)Session["admin"]).AdminName;

            Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

            ViewBag.RestoranIsmi = girisYapanAdmin.Name;

            Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

            ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

            ViewBag.RestoranPuanı = girisYapanAdmin.Score;

            ViewBag.RestoranResmi = girisYapanAdmin.Image;

            ViewBag.Yorumlar = CommentRepository.GetAllCommentByRestaurantID(girisYapanAdmin.ID);

            ViewBag.Siparisler = OrderRepository.GetAllOrderByRestaurantID(girisYapanAdmin.ID);

            return View();
        }


        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminOrderConfirm(int? id)
        {
            OrderRepository.OrderConfirm((int)id);

            OrderRepository.OrderSave();

            return Redirect("/Restaurant/AdminOrder");
        }


        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminOrderDelivery(int? id)
        {
            OrderRepository.OrderDeliver((int)id);

            OrderRepository.OrderSave();

            return Redirect("/Restaurant/AdminOrder");
        }




        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminAddFood()
        {
           
            ViewBag.Admin = ((RestaurantVM)Session["admin"]).AdminName;

            string adminName = ((RestaurantVM)Session["admin"]).AdminName;

            Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

            ViewBag.RestoranID = girisYapanAdmin.ID;

            ViewBag.RestoranIsmi = girisYapanAdmin.Name;

            Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

            ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

            ViewBag.RestoranPuanı = girisYapanAdmin.Score;

            ViewBag.RestoranResmi = girisYapanAdmin.Image;

            ViewBag.Yorumlar = CommentRepository.GetAllCommentByRestaurantID(girisYapanAdmin.ID);

            ViewBag.Siparisler = OrderRepository.GetAllOrderByRestaurantID(girisYapanAdmin.ID);

            ViewBag.Kategoriler = _dbContext.Categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()

            }).ToList();

            return View();
        }


        [HttpPost]
        public ActionResult AdminAddFood(FoodDTO food)
        {
            if (ModelState.IsValid)
            {
                

                string adminName = ((RestaurantVM)Session["admin"]).AdminName;

                ViewBag.Admin = ((RestaurantVM)Session["admin"]).AdminName;

                var restoran = RestaurantRepository.GetRestaurantByAdmin(adminName);

                ViewBag.RestoranID = restoran.ID;

                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    if (fileName + extension != "")
                    {
                        string imagePath = "~/Images/" + fileName + extension;
                        Request.Files[0].SaveAs(Server.MapPath(imagePath));
                        food.RestaurantSpecificImage = "~/Images/" + fileName + extension;
                    }
                }


                foodRepository.AddFood(food, adminName, restoran.ID);

                foodRepository.FoodSave();

                return Redirect("/Restaurant/AdminMenu");
            }

            else
            {
               

                ViewBag.Admin = ((RestaurantVM)Session["admin"]).AdminName;

                string adminName = ((RestaurantVM)Session["admin"]).AdminName;

                Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

                ViewBag.RestoranID = girisYapanAdmin.ID;

                ViewBag.RestoranIsmi = girisYapanAdmin.Name;

                Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

                ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

                ViewBag.RestoranPuanı = girisYapanAdmin.Score;

                ViewBag.Yorumlar = CommentRepository.GetAllCommentByRestaurantID(girisYapanAdmin.ID);

                ViewBag.Siparisler = OrderRepository.GetAllOrderByRestaurantID(girisYapanAdmin.ID);

                ViewBag.Kategoriler = _dbContext.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()

                }).ToList();

                return View();
            }


        }



        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminEditFood(int? id)
        {
            

            string adminName = ((RestaurantVM)Session["admin"]).AdminName;

            Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

            int foodID = (int)id;

            ViewBag.YemekID = foodID;

            ViewBag.Kategoriler = _dbContext.Categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()

            }).ToList();

            int maxSale = (int)_dbContext.Foods.Max(x => x.NumberOfSales);

            Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

            ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

            ViewBag.RestoranPuanı = girisYapanAdmin.Score;

            return View();
        }

        [HttpPost]
        public ActionResult AdminEditFood(FoodDTO food)
        {
            
            if (ModelState.IsValid)
            {
                string adminName = ((RestaurantVM)Session["admin"]).AdminName;

                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    if (fileName + extension != "")
                    {
                        string imagePath = "~/Images/" + fileName + extension;
                        Request.Files[0].SaveAs(Server.MapPath(imagePath));
                        food.RestaurantSpecificImage = "~/Images/" + fileName + extension;
                    }
                }

                food.Discriminator = adminName;

                foodRepository.UpdateFood(food);

                foodRepository.FoodSave();


                return Redirect("/Restaurant/AdminMenu");
            }

            else
            {

                string adminName = ((RestaurantVM)Session["admin"]).AdminName;

                Restaurant girisYapanAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

                int foodID = food.ID;

                ViewBag.YemekID = foodID;

                ViewBag.Kategoriler = _dbContext.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()

                }).ToList();

                int maxSale = (int)_dbContext.Foods.Max(x => x.NumberOfSales);

                Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

                ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

                ViewBag.RestoranPuanı = girisYapanAdmin.Score;

                return View();
            }

        }


        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminEdit()
        {

            ViewBag.Semtler = _dbContext.Districts.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()

            }).ToList();

            string adminName = ((RestaurantVM)Session["admin"]).AdminName;

            Restaurant restoran = RestaurantRepository.GetRestaurantByAdmin(adminName);

            ViewBag.RestoranID = restoran.ID;

            Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

            ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

            ViewBag.RestoranIsmi = restoran.Name;

            ViewBag.RestoranResmi = restoran.Image;

            ViewBag.RestoranPuanı = restoran.Score;

            return View();
        }

        [HttpPost]
        public ActionResult AdminEdit(RestaurantDTO restoran)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    if (fileName + extension != "")
                    {
                        string imagePath = "~/Images/" + fileName + extension;
                        Request.Files[0].SaveAs(Server.MapPath(imagePath));
                        restoran.Image = "~/Images/" + fileName + extension;
                    }
                }

                RestaurantRepository.UpdateRestaurant(restoran);

                RestaurantRepository.SaveRestaurant();

                Session.Clear();

                return Redirect("/Restaurant/LogIn");

            }

            else
            {
                

                ViewBag.Semtler = _dbContext.Districts.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()

                }).ToList();

                string adminName = ((RestaurantVM)Session["admin"]).AdminName;

                Restaurant restoranAdmin = RestaurantRepository.GetRestaurantByAdmin(adminName);

                ViewBag.RestoranID = restoranAdmin.ID;

                Food enCokSatanUrun = foodRepository.GetFoodByMaxSale();

                ViewBag.EnCokSatanUrun = enCokSatanUrun.RestaurantSpecificName;

                ViewBag.RestoranIsmi = restoranAdmin.Name;

                ViewBag.RestoranPuanı = restoranAdmin.Score;

                return View();
            }


        }


        [AdminAuthorization(Role = "admin")]
        public ActionResult AdminCommentConfirm(int? id)
        {
           

            CommentRepository.CommentConfirm((int)id);

            CommentRepository.SaveComment();

            return Redirect("/Restaurant/AdminComment");
        }



        
        public ActionResult RestaurantRegister()
        {
           

            ViewBag.Semtler = _dbContext.Districts.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()

            }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult RestaurantRegister(Restaurant restoran)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                if (fileName + extension != "")
                {
                    string imagePath = "~/Images/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(imagePath));
                    restoran.Image = "~/Images/" + fileName + extension;
                }
            }

            RestaurantRepository.CreateRestaurant(restoran);

            RestaurantRepository.SaveRestaurant();

            return Redirect("/Home/Index");
        }



    }
}