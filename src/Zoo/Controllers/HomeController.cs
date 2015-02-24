using System.Linq;
using System.Web.Mvc;
using Zoo.Models;
using Zoo.Models.ViewModels.Home;

namespace Zoo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new ZooDbContext())
            {
                var model = new IndexViewModel
                {
                    Animals = db.Animals.Select(x => new AnimalWithEnclosureModel
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
}