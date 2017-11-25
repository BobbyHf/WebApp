using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPaging.Startup))]
namespace MvcPaging
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
