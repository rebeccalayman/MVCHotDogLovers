using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotDogLover.Startup))]
namespace HotDogLover
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
