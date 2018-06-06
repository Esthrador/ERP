using System.Globalization;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERPv1.Startup))]
namespace ERPv1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var cultureInfo = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
