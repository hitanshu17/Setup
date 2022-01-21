using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class idea_entryController : Controller
    {
        private dmdbEntities db = new dmdbEntities();

        // GET: idea_entry
        public ActionResult Index()
        {
            return View(db.idea_entry.ToList());
        }

        // GET: idea_entry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idea_entry idea_entry = db.idea_entry.Find(id);
            if (idea_entry == null)
            {
                return HttpNotFound();
            }
            return View(idea_entry);
        }

        // POST: idea_entry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,headings,itags,inotes")] idea_entry idea_entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea_entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idea_entry);
        }

        // GET: idea_entry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idea_entry idea_entry = db.idea_entry.Find(id);
            if (idea_entry == null)
            {
                return HttpNotFound();
            }
            return View(idea_entry);
        }

        // POST: idea_entry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            idea_entry idea_entry = db.idea_entry.Find(id);
            db.idea_entry.Remove(idea_entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ideaApproved()
        {
            return View();
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
