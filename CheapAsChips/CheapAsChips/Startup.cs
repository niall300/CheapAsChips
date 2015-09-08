using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheapAsChips.Startup))]
namespace CheapAsChips
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
