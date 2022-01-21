using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class user_entryController : Controller
    {
        private dmdbEntities db = new dmdbEntities();

        // GET: user_entry
        public ActionResult Index()
        {
            return View(db.user_entry.ToList());
        }



        // GET: user_entry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_entry user_entry = db.user_entry.Find(id);
            if (user_entry == null)
            {
                return HttpNotFound();
            }
            return View(user_entry);
        }

        // POST: user_entry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,comp_name,ctags,caddress,cemail,caltemail,cmobile,caltmobile,addnotes")] user_entry user_entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_entry);
        }

        // GET: user_entry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_entry user_entry = db.user_entry.Find(id);
            if (user_entry == null)
            {
                return HttpNotFound();
            }
            return View(user_entry);
        }

        // POST: user_entry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_entry user_entry = db.user_entry.Find(id);
            db.user_entry.Remove(user_entry);
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
