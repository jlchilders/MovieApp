using MovieApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBEntities _db = new MoviesDBEntities();

        public ActionResult Index()

        {

            return View(_db.Movies.ToList());

        }
        // GET: /Home/Create 

        public ActionResult Create()

        {

            return View();

        }

        // POST: /Home/Create 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Create([Bind(Exclude = "Id")] Movie movieToCreate)

        {
            if (!ModelState.IsValid)

                return View();

            _db.Movies.Add(movieToCreate);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}