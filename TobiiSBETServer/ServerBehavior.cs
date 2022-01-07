// Target: .NET 6 (LTS)

// Default
using System;
// Additional
// Third-party
using WebSocketSharp;
using WebSocketSharp.Server;


namespace TobiiSBETServer
{
    internal class ServerBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Send("Pong from server");
        }

        protected override void OnOpen()
        {
            base.OnOpen();
        }
    }
}
