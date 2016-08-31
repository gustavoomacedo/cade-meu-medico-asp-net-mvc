using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CadeMeuMedico.Startup))]
namespace CadeMeuMedico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
