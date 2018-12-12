using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SDMS.App.Startup))]
namespace SDMS.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
