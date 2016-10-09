using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EAutoServicing.Startup))]
namespace EAutoServicing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
