using System;
using WebSocketSharp;
using WebSocketSharp.Server;

class MyWebSocketService : WebSocketBehavior
{
    protected override void OnOpen()
    {
        Console.WriteLine($"WebSocket connection opened. ID: {ID}");
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        string receivedMessage = e.Data;
        Console.WriteLine($"Received Message: {receivedMessage}");

        // Send a response back to the client
        Send("Server received your message: " + receivedMessage);
    }

    protected override void OnError(ErrorEventArgs e)
    {
        Console.WriteLine($"WebSocket error: {e.Message}");
    }

    protected override void OnClose(CloseEventArgs e)
    {
        Console.WriteLine($"WebSocket connection closed. ID: {ID}, Code: {e.Code}, Reason: {e.Reason}");
    }
}




class Program
{
    static void Main(string[] args)
    {
        var wssv = new WebSocketServer(8080);
        wssv.AddWebSocketService<MyWebSocketService>("/chat");
        wssv.Start();

        Console.WriteLine("WebSocket Server is running on ws://localhost:8080/chat");
        Console.ReadLine();

        wssv.Stop();
    }
}

