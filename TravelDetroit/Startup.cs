using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelDetroit.Startup))]
namespace TravelDetroit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
