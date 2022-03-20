using System;
using WebSocketSharp.NetCore;
using System.Security.Cryptography.X509Certificates;
using WebSocketSharp.NetCore.Server;

namespace Server
{
    public class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = System.Text.Encoding.UTF8.GetString(e.RawData);
            Console.WriteLine("Got Message: " + msg);
            Send(msg);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var wssv = new WebSocketServer(7777, true);

            wssv.SslConfiguration.ServerCertificate =
                new X509Certificate2("cert_jdj_password.pfx", "password");

            wssv.AddWebSocketService<Echo>("/echo");
            wssv.Start();
            Console.Read();
            wssv.Stop();
        }
    }
}