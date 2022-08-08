using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalr.Server
{
    public class TestHub: Hub
    {
        public async Task Send(string text)
        {           
            // Envia a todos los clientes el texto con la etiqueta 'ReceivedInformation'
            await Clients.All.SendAsync("ReceivedInformation", text);
        }
    }
}