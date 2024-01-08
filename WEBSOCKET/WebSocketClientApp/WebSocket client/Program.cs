using System;
using WebSocketSharp;

class Program
{
    static void Main(string[] args)
    {
        using (var ws = new WebSocket("ws://localhost:8080/chat"))
        {
            ws.OnOpen += (sender, e) =>
            {
                Console.WriteLine("WebSocket connection opened.");
            };

            ws.OnMessage += (sender, e) =>
            {
                Console.WriteLine($"Received Message: {e.Data}");
            };

            ws.OnError += (sender, e) =>
            {
                Console.WriteLine($"WebSocket error: {e.Message}");
            };

            ws.OnClose += (sender, e) =>
            {
                Console.WriteLine($"WebSocket connection closed. Code: {e.Code}, Reason: {e.Reason}");
            };

            ws.Connect();
            while (true)
            {
                ws.Send("Hello, Server!"); 
                Console.ReadLine();

            }
            Console.WriteLine("WebSocket Client connected to ws://localhost:8080/chat");


            


            Console.ReadLine(); 
        }
    }
}
