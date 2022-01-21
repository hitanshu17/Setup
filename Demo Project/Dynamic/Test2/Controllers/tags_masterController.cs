using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class tags_masterController : Controller
    {
        private dmdbEntities db = new dmdbEntities();

        // GET: tags_master
        public ActionResult Index()
        {
            return View(db.tags_master.ToList());
        }

        // GET: tags_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tags_master tags_master = db.tags_master.Find(id);
            if (tags_master == null)
            {
                return HttpNotFound();
            }
            return View(tags_master);
        }

        // GET: tags_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tags_master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tags")] tags_master tags_master)
        {
            if (ModelState.IsValid)
            {
                db.tags_master.Add(tags_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tags_master);
        }

        // GET: tags_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tags_master tags_master = db.tags_master.Find(id);
            if (tags_master == null)
            {
                return HttpNotFound();
            }
            return View(tags_master);
        }

        // POST: tags_master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tags")] tags_master tags_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tags_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tags_master);
        }

        // GET: tags_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tags_master tags_master = db.tags_master.Find(id);
            if (tags_master == null)
            {
                return HttpNotFound();
            }
            return View(tags_master);
        }

        // POST: tags_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tags_master tags_master = db.tags_master.Find(id);
            db.tags_master.Remove(tags_master);
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

        [HttpPost]
        public JsonResult Save(tags_master tg)
        {
            db.tags_master.Add(tg);
            db.SaveChanges();
            return Json(tg);
        }



    }
}
