using System.Web.Hosting;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartup(typeof(DotVVMSample.Startup))]
namespace DotVVMSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            var applicationPhysicalPath = HostingEnvironment.ApplicationPhysicalPath;


            // use DotVVM
            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(applicationPhysicalPath, options: options =>
            {
                options.AddDefaultTempStorages("temp");
            });
#if !DEBUG
            dotvvmConfiguration.Debug = false;
#endif

            // use static files
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileSystem = new PhysicalFileSystem(applicationPhysicalPath)
            });

        }
    }
}
