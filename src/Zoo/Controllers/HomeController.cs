using System.Linq;
using System.Web.Mvc;
using Zoo.Models;
using Zoo.Models.ViewModels.Home;

namespace Zoo.Controllers
{
    public class HomeController : Controller
    {
        public virtual IZooDbContext Database { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Database = new ZooDbContext();
            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel
            {
                Animals = Database.Animals.Select(x => new AnimalWithEnclosureModel
                {
                    AnimalId = x.Id,
                    EnclosureId = x.EnclosureId,
                    AnimalName = x.Name,
                    EnclosureName = x.Enclosure.Name
                }).ToList()
            };

            return View(model);
        }
    }
}