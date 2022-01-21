using System.Web.Mvc;
using Test2.Models;
namespace Test2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        dmdbEntities db = new dmdbEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user_entry usr)
        {

            db.user_entry.Add(usr);
            db.SaveChanges();

            return View(usr);
        }

        public ActionResult ToDo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ToDo(idea_entry idea)
        {

            db.idea_entry.Add(idea);
            db.SaveChanges();

            return View(idea);
        }

    }
}