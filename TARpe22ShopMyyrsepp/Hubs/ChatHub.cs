using Microsoft.AspNetCore.SignalR;

namespace TARpe22ShopMyyrsepp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.Now);
        
        }
    }
}
