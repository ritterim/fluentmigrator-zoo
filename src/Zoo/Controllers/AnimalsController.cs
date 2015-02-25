using System;
using System.Web.Mvc;
using Zoo.Models;

namespace Zoo.Controllers
{
    public class AnimalsController : Controller
    {
        public virtual IZooDbContext Database { get; set; }

        public AnimalsController()
        {}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Database = new ZooDbContext();
            base.OnActionExecuting(filterContext);
        }

        // GET: Animals
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Animal animal)
        {
            Database.Animals.Add(animal);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}