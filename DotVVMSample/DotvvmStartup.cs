using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVMSample.components;

namespace DotVVMSample
{
    public class DotvvmStartup : IDotvvmStartup
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Chat", "chat", "Views/chat.dothtml");
            config.RouteTable.Add("Home", "", "Views/home.dothtml");

            // Uncomment the following line to auto-register all dothtml files in the Views folder
            // config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
            config.Markup.AddCodeControls("cc", typeof(SampleComponent).Namespace,
                typeof(SampleComponent).Assembly.GetName().Name);

            config.Markup.AddCodeControls("cc", typeof(MyDatePicker).Namespace,
                typeof(SampleComponent).Assembly.GetName().Name);
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("signalr-client", new ScriptResource
            {
                Location = new UrlResourceLocation("~/Scripts/jquery.signalR-2.2.2.min.js"),
                Dependencies = new [] {"jquery"}
            });


            config.Resources.Register("signalr-hubs", new ScriptResource
            {
                Location = new UrlResourceLocation("~/signalr/hubs"),
                Dependencies = new[] {"signalr-client"}
            });


            config.Resources.Register("bootstrap", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/Content/bootstrap.min.css")
            });


            config.Resources.Register("customScript", new ScriptResource
            {
                Location = new UrlResourceLocation("~/Scripts/scripts.js")
            });


            config.Resources.Register("datepicker-js", new ScriptResource
            {
                Location = new UrlResourceLocation("~/Scripts/bootstrap-datepicker.js"),
                Dependencies = new[] {"jquery", "bootstrap"}
            });

            config.Resources.Register("datepicker-css", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/Content/datepicker.css")
            });


            config.Resources.Register("chatSync", new ScriptResource
            {
                Location =  new UrlResourceLocation("~/Scripts/chatSync.js"),
                Dependencies = new []{"signalr-hubs"}
            });

            // custom knockout handler file
            config.Resources.Register("myDatePicker", new ScriptResource
            {
                Location = new UrlResourceLocation("~/Scripts/myDatePicker.js"),
                Dependencies = new[] {"knockout", "datepicker-js", "datepicker-css"}
            });
        }
    }
}