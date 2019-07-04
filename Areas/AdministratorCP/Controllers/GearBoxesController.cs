using System.Linq;
using System.Net;
using System.Web.Mvc;
using BookCarProjectMaster.Models;

namespace BookCarProjectMaster.Areas.AdministratorCP.Controllers
{
    [Authorize(Roles = "MANAGER, ADMIN")]
    public class GearBoxesController : Controller
    {
        private DbBookCarContext db = new DbBookCarContext();

        // GET: GearBoxes
        public ActionResult Index()
        {
            return View(db.GearBoxs.ToList());
        }

        // GET: GearBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearBox gearBox = db.GearBoxs.Find(id);
            if (gearBox == null)
            {
                return HttpNotFound();
            }
            return View(gearBox);
        }

        // GET: GearBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GearBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GearBoxsId,NameGearBox")] GearBox gearBox)
        {
            if (ModelState.IsValid)
            {
                db.GearBoxs.Add(gearBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gearBox);
        }

        // GET: GearBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearBox gearBox = db.GearBoxs.Find(id);
            if (gearBox == null)
            {
                return HttpNotFound();
            }
            return View(gearBox);
        }

        // POST: GearBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GearBoxsId,NameGearBox")] GearBox gearBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gearBox).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gearBox);
        }

        [Authorize(Roles = "ADMIN")]
        // GET: GearBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearBox gearBox = db.GearBoxs.Find(id);
            if (gearBox == null)
            {
                return HttpNotFound();
            }
            return View(gearBox);
        }

        // POST: GearBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GearBox gearBox = db.GearBoxs.Find(id);
            db.GearBoxs.Remove(gearBox);
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
