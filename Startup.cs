using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(w03b.Startup))]
namespace w03b
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
