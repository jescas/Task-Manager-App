using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskManagerProject.Startup))]
namespace TaskManagerProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
