using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zoo.Startup))]
namespace Zoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
