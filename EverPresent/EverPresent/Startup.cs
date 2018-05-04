using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EverPresent.Startup))]
namespace EverPresent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
