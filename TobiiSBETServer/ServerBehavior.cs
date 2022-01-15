// Target: .NET 6 (LTS)

// Default
using System;
// Additional
// Third-party
using WebSocketSharp;
using WebSocketSharp.Server;


namespace TobiiSBETServer
{
    /// <summary>
    /// Server behavior class for WebSocket
    /// </summary>
    internal class ServerBehavior : WebSocketBehavior
    {
        /// <summary>
        /// When a message was arrived
        /// </summary>
        /// <param name="e">Args</param>
        protected override void OnMessage(MessageEventArgs e)
        {
            Send("This is a Tobii SBET Data Server");
        }

        /// <summary>
        /// When the connection is opened
        /// </summary>
        protected override void OnOpen()
        {
            base.OnOpen();
        }
    }
}
