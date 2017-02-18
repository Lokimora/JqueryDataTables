using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataTableTests.Startup))]
namespace DataTableTests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
