using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MetanitGuidModded.Startup))]
namespace MetanitGuidModded
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
