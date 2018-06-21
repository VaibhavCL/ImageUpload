using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageUplaodApplication.Startup))]
namespace ImageUplaodApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
