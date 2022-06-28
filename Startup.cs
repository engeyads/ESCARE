using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESCARE.Startup))]
namespace ESCARE
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
