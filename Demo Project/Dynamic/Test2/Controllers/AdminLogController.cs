using System.Data;
using System.Linq;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class AdminLogController : Controller
    {
        // GET: AdminLog
        dmdbEntities db = new dmdbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user_log ad)
        {
            int count = db.user_log.Where(p => p.username == ad.username && p.password == ad.password).Count();

            if (count > 0)
            {
                user_log info = (from c in db.user_log where c.username == ad.username select c).FirstOrDefault();
                Session["username"] = ad.username;
                Session["Id"] = info.id;
                return RedirectToAction("Index");
            }


            else
            {
                Response.Write("<script>alert('Invaid User ID & Password');</script");
            }

            return View(ad);

        }

    }

}