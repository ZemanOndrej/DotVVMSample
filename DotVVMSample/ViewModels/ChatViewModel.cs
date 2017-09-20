using System.Collections.Generic;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace DotVVMSample.ViewModels
{


    public class ChatViewModel : MainViewModel,IHub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            HubClients.All.broadcastMessage(name, message);
        }


        public ChatViewModel()
        {
            HubClients = new HubConnectionContext();
        }

        [JsonIgnore]
        internal IHubCallerConnectionContext<dynamic> HubClients { get; set; }

        [JsonIgnore]
        IHubCallerConnectionContext<dynamic> IHub.Clients
        {
            get => HubClients;
            set => HubClients = value;
        }

        [JsonIgnore]
        public HubCallerContext Context { get; set; }

        [JsonIgnore]
        public IGroupManager Groups { get; set; }

        public virtual Task OnDisconnected(bool stopCalled)
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }

        public virtual Task OnConnected()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }

        public virtual Task OnReconnected()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }





}