using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(psycoder.Startup))]
namespace psycoder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
