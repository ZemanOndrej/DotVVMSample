using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls.Infrastructure;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using DotVVM.Framework.Runtime.Tracing;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json.Linq;

namespace DotVVMSample.ViewModels
{

    public class DotvvmHubContext : HubCallerContext,IDotvvmRequestContext
    {
        public string GetSpaContentPlaceHolderUniqueId()
        {
            throw new NotImplementedException();
        }

        public void ChangeCurrentCulture(string cultureName)
        {
            throw new NotImplementedException();
        }

        public void ChangeCurrentCulture(string cultureName, string uiCultureName)
        {
            throw new NotImplementedException();
        }

        public CultureInfo GetCurrentUICulture()
        {
            throw new NotImplementedException();
        }

        public CultureInfo GetCurrentCulture()
        {
            throw new NotImplementedException();
        }

        public void InterruptRequest()
        {
            throw new NotImplementedException();
        }

        public string GetSerializedViewModel()
        {
            throw new NotImplementedException();
        }

        public void RedirectToUrl(string url, bool replaceInHistory = false, bool allowSpaRedirect = false)
        {
            throw new NotImplementedException();
        }

        public void RedirectToRoute(string routeName, object newRouteValues = null, bool replaceInHistory = false,
            bool allowSpaRedirect = true, string urlSuffix = null)
        {
            throw new NotImplementedException();
        }

        public void RedirectToUrlPermanent(string url, bool replaceInHistory = false, bool allowSpaRedirect = false)
        {
            throw new NotImplementedException();
        }

        public void RedirectToRoutePermanent(string routeName, object newRouteValues = null, bool replaceInHistory = false,
            bool allowSpaRedirect = true)
        {
            throw new NotImplementedException();
        }

        public void FailOnInvalidModelState()
        {
            throw new NotImplementedException();
        }

        public string TranslateVirtualPath(string virtualUrl)
        {
            throw new NotImplementedException();
        }

        public void ReturnFile(byte[] bytes, string fileName, string mimeType, IEnumerable<KeyValuePair<string, string>> additionalHeaders = null)
        {
            throw new NotImplementedException();
        }

        public void ReturnFile(Stream stream, string fileName, string mimeType, IEnumerable<KeyValuePair<string, string>> additionalHeaders = null)
        {
            throw new NotImplementedException();
        }

        public IHttpContext HttpContext { get; }
        public string CsrfToken { get; set; }
        public JObject ReceivedViewModelJson { get; set; }
        public object ViewModel { get; set; }
        public JObject ViewModelJson { get; set; }
        public Dictionary<string, string> PostBackUpdatedControls { get; }
        public DotvvmView View { get; set; }
        public DotvvmConfiguration Configuration { get; }
        public IDotvvmPresenter Presenter { get; set; }
        public RouteBase Route { get; set; }
        public bool IsPostBack { get; set; }
        public IDictionary<string, object> Parameters { get; set; }
        public ResourceManager ResourceManager { get; }
        public ModelState ModelState { get; }
        public IQueryCollection Query { get; }
        public bool IsCommandExceptionHandled { get; set; }
        public bool IsPageExceptionHandled { get; set; }
        public Exception CommandException { get; set; }
        public bool IsSpaRequest { get; }
        public bool IsInPartialRenderingMode { get; }
        public string ResultIdFragment { get; set; }
        public IServiceProvider Services { get; }
        public List<IRequestTracer> RequestTracers { get; }
    }
}