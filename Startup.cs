using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Logix_Guru.Startup))]
namespace Logix_Guru
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
