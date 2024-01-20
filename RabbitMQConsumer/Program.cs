using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using MessagingService.Model;
using MessagingService.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

public class DatabaseService
{
    private readonly IDataRepository _dataRepository;

    public DatabaseService(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
    }

    public void SaveToDatabase(string message)
    {
        var newMessage = new Message { Body = message };
        _dataRepository.AddMessage(newMessage);
        Console.WriteLine($"Saving message to database: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<MessagingDbContext>(options => options.UseSqlServer("Server=host.docker.internal,1433;User=SA;Password=Welkom12345;TrustServerCertificate=true;"))
            .AddScoped<IDataRepository, DataRepository>()
            .BuildServiceProvider();

        var dataRepository = serviceProvider.GetRequiredService<IDataRepository>();
        var databaseService = new DatabaseService(dataRepository);

        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("product", exclusive: false);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, eventArgs) => {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Product message received: {message}");

            databaseService.SaveToDatabase(message);
        };

        channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);

        Console.ReadKey();
    }
}