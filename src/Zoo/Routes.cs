using System.Web.Routing;
using RestfulRouting;
using Zoo.Controllers;

namespace Zoo
{
    public class Routes : RouteSet
    {
        public override void Map(IMapper map)
        {
            map.DebugRoute("routedebug");
            map.Root<HomeController>(h => h.Index());
            map.Resources<AnimalsController>();
            map.Resources<KeepersController>();
            map.Resources<EnclosuresController>();
        }

        public static void Start(RouteCollection routes)
        {
            routes.MapRoutes<Routes>();
        }
    }
}