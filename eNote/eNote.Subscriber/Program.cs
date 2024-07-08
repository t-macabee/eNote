using EasyNetQ;
using eNote.Model;


var bus = RabbitHutch.CreateBus("host=localhost");
await bus.PubSub.SubscribeAsync<EntityCreated<Korisnik>>("consolePrinter", msg => 
{
    Console.WriteLine($"Korisnik registrovan: {msg}");
});

Console.WriteLine("Listening for messages, press <return> key to close.");
Console.ReadLine();
