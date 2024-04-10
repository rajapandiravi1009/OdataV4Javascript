using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EJGrid.Startup))]
namespace EJGrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
