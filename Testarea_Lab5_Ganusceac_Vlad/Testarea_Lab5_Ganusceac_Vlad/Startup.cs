using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testarea_Lab5_Ganusceac_Vlad.Startup))]
namespace Testarea_Lab5_Ganusceac_Vlad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
