using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookCarProjectMaster.Models;

namespace BookCarProjectMaster.Areas.AdministratorCP.Controllers
{
    [Authorize(Roles = "MANAGER, ADMIN")]
    public class CarCategoriesController : Controller
    {
        private DbBookCarContext db = new DbBookCarContext();

        // GET: CarCategories
        public ActionResult Index()
        {
            return View(db.CarCategories.ToList());
        }

        // GET: CarCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }

        // GET: CarCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarCategoryId,NameCarCategory,CarCategoryStatus")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                db.CarCategories.Add(carCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carCategory);
        }

        // GET: CarCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }

        // POST: CarCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarCategoryId,NameCarCategory,CarCategoryStatus")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carCategory).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carCategory);
        }

        [Authorize(Roles = "ADMIN")]
        // GET: CarCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }

        // POST: CarCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarCategory carCategory = db.CarCategories.Find(id);
            db.CarCategories.Remove(carCategory);
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
    }
}
