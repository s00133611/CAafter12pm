using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CA2S00133611.Startup))]
namespace CA2S00133611
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
