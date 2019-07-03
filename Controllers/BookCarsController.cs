using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BookCarProjectMaster.Models;

namespace BookCarProjectMaster.Controllers
{
    public class BookCarsController : Controller
    {
        private DbBookCarContext db = new DbBookCarContext();

        // GET: BookCars
        public ActionResult Index()
        {
            var bookCars = db.BookCars.Include(b => b.CarProduct);
            return View(bookCars.ToList());
        }

        // GET: BookCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCar bookCar = db.BookCars.Find(id);
            if (bookCar == null)
            {
                return HttpNotFound();
            }
            return View(bookCar);
        }

        // GET: BookCars/Create
        public ActionResult Create()
        {
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar");
            return View();
        }

        // POST: BookCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookCarsId,DateBookCar,TotalRental,DateOfReceive,DateReturn,PaymentStatus,FullNameUser,CardIDUser,AddressUser,NumberPhoneUser,EmailUser,CarProductsId")] BookCar bookCar)
        {
            if (ModelState.IsValid)
            {
                db.BookCars.Add(bookCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar", bookCar.CarProductsId);
            return View(bookCar);
        }

        // GET: BookCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCar bookCar = db.BookCars.Find(id);
            if (bookCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar", bookCar.CarProductsId);
            return View(bookCar);
        }

        // POST: BookCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookCarsId,DateBookCar,TotalRental,DateOfReceive,DateReturn,PaymentStatus,FullNameUser,CardIDUser,AddressUser,NumberPhoneUser,EmailUser,CarProductsId")] BookCar bookCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar", bookCar.CarProductsId);
            return View(bookCar);
        }

        // GET: BookCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCar bookCar = db.BookCars.Find(id);
            if (bookCar == null)
            {
                return HttpNotFound();
            }
            return View(bookCar);
        }

        // POST: BookCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCar bookCar = db.BookCars.Find(id);
            db.BookCars.Remove(bookCar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[HttpPost]
        //public ActionResult DatXe(FormCollection collection)
        //{
        //    BookCar bookCar = new BookCar();
        //    foreach(var item in BookCar)
        //    return RedirectToAction("Xacnhan", "BookCars");
        //}

        public ActionResult DatXe(int? id)
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
