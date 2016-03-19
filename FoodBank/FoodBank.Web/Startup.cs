using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodBank.Web.Startup))]
namespace FoodBank.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
