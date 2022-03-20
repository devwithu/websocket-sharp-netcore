using System;
using System.Net.WebSockets;
using WebSocketSharp.NetCore;
using System.Threading;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // test WebSocketSharp  

            using (var ws = new WebSocket ("wss://hp.rush79.com:7777/echo"))
            {
                Console.WriteLine("ReadyState = " + ws.ReadyState.ToString()); // ReadyState=Connecting 상태

                ws.OnOpen += (sender, e) => //ws.Send("Hi, there!");
                {
                    Console.WriteLine("OnOpen");
                    Console.WriteLine("ReadyState = " + ws.ReadyState.ToString()); // ws.Connect 가 성공적이면 ReadyState 는 Open 이며 이 상태에서 서버와 통신가능. 
                };

                ws.OnClose += (sender, e) =>
                {
                    Console.WriteLine("OnClose");
                };
                ws.OnMessage += (sender, e) =>
                {
                    Console.WriteLine("OnMessage : " + e.Data);
                };


                ws.Connect(); // Connect to the server.

                Console.WriteLine("\nType 'exit' to exit.\n");

                while (true)
                {
                    Thread.Sleep(1000);
                    Console.Write("> ");
                    var msg = Console.ReadLine();
                    if (msg == "exit")
                        break;

                    // Send a text message.
                    ws.Send(msg);
                }
            } // using (var ws = new WebSocket("ws://echo.websocket.org"))
        }


    }
}