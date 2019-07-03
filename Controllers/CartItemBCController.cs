using BookCarProjectMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookCarProjectMaster.Controllers
{
    public class CartItemBCController : Controller
    {
        DbBookCarContext db = new DbBookCarContext();
        // GET: CartItemBC
        public List<CartItem> Laygiohang()
        {
            List<CartItem> carts = Session["Giohang"] as List<CartItem>;
            if(carts == null)
            {
                carts = new List<CartItem>();
                Session["Giohang"] = carts;
            }
            return carts;
        }

        //Them vao gio hang
        public ActionResult Themgiohang(int id, string strUrl)
        {
            List<CartItem> carts = Laygiohang();
            CartItem product = carts.Find(n => n.id == id);
            if(product == null)
            {
                product = new CartItem(id);
                carts.Add(product);
                return RedirectToAction("Giohang", "CartItemBC");
            }
            else
            {
                return RedirectToAction("Giohang", "CartItemBC");
            }
        }

        //Tinh tong tien
        private decimal Tongtien()
        {
            decimal tongTien = 0;
            List<CartItem> cartItems = Session["Giohang"] as List<CartItem>;
            if(cartItems != null)
            {
                tongTien = cartItems.Sum(n => n.giaThue);
            }
            return tongTien;
        }

        //Trang gio hang
        public ActionResult Giohang()
        {
            List<CartItem> cartItems = Laygiohang();
            if(cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Tongtien = Tongtien();
            return View(cartItems);
        }

        //Dat xe
        [HttpGet]
        public ActionResult Datxe()
        {
            if(Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Lay gio hang tu Session
            List<CartItem> cartItems = Laygiohang();
            ViewBag.Tongtien = Tongtien();
            return View(cartItems);
        }

        [HttpPost]
        public ActionResult DatXe(FormCollection formCollection)
        {
            try
            {
                BookCar bookCar = new BookCar();
                List<CartItem> cartItems = Laygiohang();
                bookCar.FullNameUser = formCollection["hoTen"];
                bookCar.NumberPhoneUser = formCollection["sdt"];
                bookCar.CardIDUser = formCollection["cmnd"];
                bookCar.AddressUser = formCollection["diaChi"];
                bookCar.DateBookCar = DateTime.Now;
                var dateOfReceive = String.Format("{0:dd/MM/yyyy}", formCollection["ngayNhan"]);
                bookCar.DateOfReceive = DateTime.Parse(dateOfReceive);
                var dateReturn = String.Format("{0:dd/MM/yyyy}", formCollection["ngayTra"]);
                bookCar.DateReturn = DateTime.Parse(dateReturn);
                bookCar.PaymentStatus = false;
                db.BookCars.Add(bookCar);
                foreach (var item in cartItems)
                {
                    bookCar.CarProductsId = item.id;
                    bookCar.TotalRental = (decimal)item.giaThue;
                    db.BookCars.Add(bookCar);
                }
                db.SaveChanges();
                Session["Giohang"] = null;
            }
            catch (System.FormatException)
            {
               
            }
            return RedirectToAction("Xacnhan", "CartItemBC");
        }

        public ActionResult Xacnhan()
        {
            return View();
        }

        
    }
}