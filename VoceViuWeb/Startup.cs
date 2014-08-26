using Microsoft.Owin;
using Owin;
using SimpleInjector;
using VoceViuWeb.App_Start;

[assembly: OwinStartupAttribute(typeof(VoceViuWeb.Startup))]
namespace VoceViuWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var container = new Container();
            DependencyRegistration.RegisterDependencies(container);
        }
    }
}
