using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPlayground.Startup))]
namespace MvcPlayground
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
