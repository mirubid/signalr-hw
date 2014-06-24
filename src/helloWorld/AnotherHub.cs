using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace helloWorld
{
    public class AnotherHub : Hub
    {
        public override Task OnConnected()
        {

            Clients.All.BroadCastMessage("hub", string.Format("{0} connected", Context.QueryString["un"] ?? "somebody"));
            return base.OnConnected();
        }
        public override Task OnDisconnected()
        {
            Clients.All.BroadCastMessage("hub", string.Format("{0} disconnected", Context.Request.QueryString["un"] ?? "somebody"));
            return base.OnDisconnected();
        }
        public override Task OnReconnected()
        {
            Clients.All.BroadCastMessage("hub", string.Format("{0} reconnected", Context.Request.QueryString["un"] ?? "somebody"));
            return base.OnReconnected();
        }
        public void Hello(string groupName, string message)
        {
            if(string.IsNullOrEmpty(groupName)){
                Clients.All.BroadCastMessage(string.Format("{0}",Clients.Caller.userName, groupName), string.Format("{2}: {0} ({1})",message,this.GetType().Name,DateTime.Now));
            }else{
                Clients.Group(groupName).BroadCastMessage(string.Format("{0} ({1})",Clients.Caller.userName, groupName), string.Format("{2}: {0} ({1})",message,this.GetType().Name,DateTime.Now));
            
            }

            
        }
        public Task SendSvgShape(string shapeName,Dictionary<string, object> shapeAttrs)
        {
            return Task.Run(() =>
            {
                Hello(null, "sending svg");
                Clients.All.BroadcastSvg(shapeName,shapeAttrs);
            });
        }
        public Task JoinGroup( string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName)
                .ContinueWith((t) => { Clients.All.BroadCastMessage(Clients.Caller.userName,string.Format("group created: {0}",groupName)); });

        }
        public Task LeaveGroup(string groupName)
        {
            
            return Groups.Remove(Context.ConnectionId, groupName);
        }
        
    }
}