using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MacevalackaAplikacija.Startup))]
namespace MacevalackaAplikacija
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
