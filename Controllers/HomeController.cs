using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using BookCarProjectMaster.Models;

namespace BookCarProjectMaster.Controllers
{
    public class HomeController : Controller
    {
        private DbBookCarContext db = new DbBookCarContext();

        // GET: Home
        public ActionResult Index(string SearchString, int? cateId, int? Page_No, int Size_Of_Page = 6)
        {
            var products = db.CarProducts.Include(p => p.CarCategory).OrderBy(p => p.CarProductsId).ToPagedList(Page_No ?? 1, Size_Of_Page);
            //var products = db.CarProducts.Include(p => p.CarCategory).Where(p => p.ModelCar.Contains(SearchString) || SearchString == null).OrderBy(p => p.CarProductsId).ToPagedList(Page_No ?? 1, Size_Of_Page);
            return View(products);
        }
        public ActionResult Details(int? id)
        {
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "CarCategoryId", "NameCarCategory");
            ViewBag.FuelsId = new SelectList(db.Fuels, "FuelsId", "NameFuel");
            ViewBag.GearBoxsId = new SelectList(db.GearBoxs, "GearBoxsId", "NameGearBox");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            CarProduct product = db.CarProducts.Include(p => p.CarCategory).Where(p => p.CarProductsId == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult CourseCategories()
        {
            var courseCat = from cat in db.CarCategories select cat;
            return PartialView(courseCat);
        }
        public ActionResult TheLoaiSanPham(int id)
        {
            var products = from product in db.CarProducts where product.CarCategoryId == id select product;
            return View(products);
        }
        public ActionResult DatHangXeS(int? id)
        {
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "CarCategoryId", "NameCarCategory");
            ViewBag.FuelsId = new SelectList(db.Fuels, "FuelsId", "NameFuel");
            ViewBag.GearBoxsId = new SelectList(db.GearBoxs, "GearBoxsId", "NameGearBox");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            CarProduct product = db.CarProducts.Include(p => p.CarCategory).Where(p => p.CarProductsId == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}