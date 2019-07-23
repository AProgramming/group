using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(group.Startup))]
namespace group
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
