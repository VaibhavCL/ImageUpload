using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageWebApplication.Startup))]
namespace ImageWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
