using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TutorMeNow.Startup))]
namespace TutorMeNow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
