using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BGScheduler.Startup))]
namespace BGScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
