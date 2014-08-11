using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoceViuWeb.Startup))]
namespace VoceViuWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
