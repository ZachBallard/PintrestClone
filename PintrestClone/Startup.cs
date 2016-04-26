using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PintrestClone.Startup))]
namespace PintrestClone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
