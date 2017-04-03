using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealer1.Startup))]
namespace CarDealer1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
