using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BHIP.Model.Startup))]
namespace BHIP.Model
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}