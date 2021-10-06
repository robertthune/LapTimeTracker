using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LapTimeTracker.Startup))]
namespace LapTimeTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
