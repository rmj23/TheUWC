using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Source.Startup))]
namespace Source
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
