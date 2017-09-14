using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPartialDemo.Startup))]
namespace MVCPartialDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
