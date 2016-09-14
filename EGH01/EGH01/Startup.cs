using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EGH01.Startup))]
namespace EGH01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
