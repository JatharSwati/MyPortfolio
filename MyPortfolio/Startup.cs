using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(MyPortfolio.Startup))]
namespace MyPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
