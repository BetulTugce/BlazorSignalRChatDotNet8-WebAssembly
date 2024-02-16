using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRChatDotNet8.Hubs
{
    public class ChatHub : Hub
    {
        // Bu metot, istemcilerden (web tarayıcılarından veya diğer istemci uygulamalardan) gelen mesajları almak ve işlemek için kullanılır..
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
