using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ordering.Startup))]
namespace Ordering
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
