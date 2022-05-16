using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekDemeti_4.Data;
using YemekDemeti_4.DTO;
using YemekDemeti_4.Models;
using YemekDemeti_4.Repository;

namespace YemekDemeti_4.Controllers
{
    public class AccountController : Controller
    {
        CustomerRepository CustomerRepository = new CustomerRepository();
        AddressRepository AddressRepository = new AddressRepository();
        OrderRepository OrderRepository = new OrderRepository();
        CityRepository CityRepository = new CityRepository();
        CommentRepository CommentRepository = new CommentRepository();
        RestaurantRepository RestaurantRepository = new RestaurantRepository();
        OrderDetailsRepository OrderDetailsRepository = new OrderDetailsRepository();
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        // GET: Account
        public ActionResult LogIn()
        {

            if (Session["user"] != null)
            {
                return Redirect("/Home/index");
            }

            ViewBag.Count = Session["count"];

            ViewBag.Kullanici = Session["user"];

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(CustomerVM vm)
        {

            if (ModelState.IsValid)
            {
                Customer girenKullanici = CustomerRepository.GetCustomerByUserName(vm.UserName);

                if (girenKullanici!=null)
                {
                    if (girenKullanici.Password == vm.Password)
                    {
                        Session["user"] = vm;
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı";
                    }

                    ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girenKullanici.ID);

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



        [CustomAuthorization(Role = "user")]
        public ActionResult ProfilePage()
        {

            ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

            ViewBag.KullaniciID = girisYapanKullanici.ID;

            ViewBag.KullaniciResmi = girisYapanKullanici.Image;

            ViewBag.KullaniciTel = girisYapanKullanici.GSM;

            ViewBag.Siparisler = OrderRepository.GetAllOrderByCustomerID(girisYapanKullanici.ID);

            ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

            ViewBag.Count = Session["count"];

            ViewBag.Kullanici = Session["user"];

            return View();
        }

        [CustomAuthorization(Role = "user")]
        public ActionResult ProfileEdit()
        {

            string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

            ViewBag.KullaniciID = girisYapanKullanici.ID;

            ViewBag.KullaniciResmi = girisYapanKullanici.Image;

            ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

            ViewBag.Count = Session["count"];

            ViewBag.Kullanici = Session["user"];

            return View();
        }

        [HttpPost]

        public ActionResult ProfileEdit(CustomerDTO kullanici)
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
                        kullanici.Image = "~/Images/" + fileName + extension;
                    }
                }

                CustomerRepository.UpdateCustomer(kullanici);

                CustomerRepository.SaveCustomer();

                Session.Clear();

                return Redirect("/Account/login");
            }

            else
            {
                string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

                ViewBag.KullaniciID = girisYapanKullanici.ID;

                ViewBag.KullaniciResmi = girisYapanKullanici.Image;

                ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

                ViewBag.Count = Session["count"];

                ViewBag.Kullanici = Session["user"];

                return View();
            }

        }


        public ActionResult ProfileCreate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ProfileCreate(CustomerDTO kullanici)
        {

            Customer kayıtOlanKullanici= CustomerRepository.GetCustomerByUserName(kullanici.UserName);

            if (kayıtOlanKullanici==null)
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
                            kullanici.Image = "~/Images/" + fileName + extension;
                        }
                    }

                    CustomerRepository.CreateCustomer(kullanici);

                    CustomerRepository.SaveCustomer();

                    return Redirect("/account/login");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.Mesaj = "Bu İsimde Bir Kullanıcı Var, Lütfen Başka Bir İsim Seçiniz";

                return View();
            }

        }

        

        [CustomAuthorization(Role = "user")]
        public ActionResult AddAddress()
        {
            string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

            ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            ViewBag.KullaniciID = girisYapanKullanici.ID;

            ViewBag.Sehirler = _dbContext.Cities.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()

            }).ToList();


            ViewBag.Semtler = _dbContext.Districts.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()

            }).ToList();

            ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

            ViewBag.Count = Session["count"];

            ViewBag.Kullanici = Session["user"];

            return View();
        }

        [HttpPost]
        public ActionResult AddAddress(AddressDTO adres)
        {
            if (ModelState.IsValid)
            {
                string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

                ViewBag.KullaniciID = girisYapanKullanici.ID;

                AddressRepository.AddAddress(adres);

                AddressRepository.SaveAddress();

                return Redirect("/Account/ProfilePage");
            }
            else
            {
                string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

                ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

                ViewBag.KullaniciID = girisYapanKullanici.ID;

                ViewBag.Sehirler = _dbContext.Cities.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()

                }).ToList();


                ViewBag.Semtler = _dbContext.Districts.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()

                }).ToList();

                ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

                ViewBag.Count = Session["count"];

                ViewBag.Kullanici = Session["user"];

                return View();
            }

            
        }

        [CustomAuthorization(Role = "user")]
        public ActionResult RateAndComment(int? id)
        {
            ViewBag.Kullanici = Session["user"];

            Order siparis = OrderRepository.GetOrderByID((int)id);

            ViewBag.Siparis = siparis;

            string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

            ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

            return View();
        }

        [HttpPost]
        public ActionResult RateAndComment(Comment yorum, int submit)
        {
            CommentRepository.AddComment(yorum, submit);

            CommentRepository.SaveComment();

            List<Order> siparisler = (List<Order>)OrderRepository.GetAllOrderByRestaurantID(yorum.RestaurantID);

            var restoran = RestaurantRepository.GetRestaurantByID(yorum.RestaurantID);

            double siparisSayısı = siparisler.Count();

            double restoranPuanı = restoran.Score;

            double ortRestoranPuan = (restoranPuanı + submit) / siparisSayısı;

            ortRestoranPuan = Math.Round(ortRestoranPuan, 1);

            restoran.Score = ortRestoranPuan;

            RestaurantRepository.SaveRestaurant();

            return Redirect("/Account/ProfilePage");
        }

        [CustomAuthorization(Role = "user")]
        public ActionResult OrderDeatils(int? id)
        {
            List<OrderDetail> siparisDetayları = (List<OrderDetail>)OrderDetailsRepository.GetAllOrderDetailByOrderID((int)id);

            ViewBag.SiparisDetaylari = siparisDetayları;

            string kullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            Customer girisYapanKullanici = CustomerRepository.GetCustomerByUserName(kullaniciIsmi);

            ViewBag.Adresler = AddressRepository.GetAllAddressByCustomerID(girisYapanKullanici.ID);

            ViewBag.Count = Session["count"];

            ViewBag.KullaniciIsmi = ((CustomerVM)Session["user"]).UserName;

            ViewBag.Kullanici = Session["user"];

            return View();
        }

    }
}