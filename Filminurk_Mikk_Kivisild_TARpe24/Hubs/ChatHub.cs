using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Filminurk_Mikk_Kivisild_TARpe24.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var userName = Context.User?.Identity?.Name ?? "Unknown";
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }
    }
}
