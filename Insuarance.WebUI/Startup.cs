using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Insuarance.WebUI.Startup))]
namespace Insuarance.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
