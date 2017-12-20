using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BreatheEasyApp.Startup))]
namespace BreatheEasyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
