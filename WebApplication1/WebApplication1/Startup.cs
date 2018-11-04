using Microsoft.Owin;
using MVC_Repository_Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MVC_Repository_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
