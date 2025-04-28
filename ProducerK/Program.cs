using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using System.Threading;
class Program
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.WriteLine("Enter a message (or leave empty to exit):\r\n");
    /* string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            var result = await producer.ProduceAsync("my-topic", new Message<Null, string> { Value = input });
            Console.WriteLine($"Message sent: {result.Value} to partition {result.Partition}");
        } */
       int i = 0;
        while (i<=1000)
        {
            Thread.Sleep(250);
            var result = await producer.ProduceAsync("my-topic", new Message<Null, string> { Value = "Nomer soobsheniya "+i+";" });
            Console.WriteLine($"Message sent: {result.Value} to partition {result.Partition}");
            i++;
        }
    }
}