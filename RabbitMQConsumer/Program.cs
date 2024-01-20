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
        // Use the injected IDataRepository to save the message to the database
        var newMessage = new Message { Body = message };
        _dataRepository.AddMessage(newMessage);
        Console.WriteLine($"Saving message to database: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Set up dependency injection manually
        var serviceProvider = new ServiceCollection()
            .AddDbContext<MessagingDbContext>(options => options.UseSqlServer("Server=host.docker.internal,1433;User=SA;Password=Welkom12345;TrustServerCertificate=true;"))  // Replace with your actual connection string
            .AddScoped<IDataRepository, DataRepository>()
            .BuildServiceProvider();

        // Create the DatabaseService with the injected IDataRepository
        var dataRepository = serviceProvider.GetRequiredService<IDataRepository>();
        var databaseService = new DatabaseService(dataRepository);

        // Set up RabbitMQ connection and channel
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        // Declare the queue after mentioning name and a few property related to that
        channel.QueueDeclare("product", exclusive: false);

        // Set Event object which listens to messages from the channel sent by the producer
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, eventArgs) => {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Product message received: {message}");

            // Save the message to the database using the DatabaseService
            databaseService.SaveToDatabase(message);
        };

        // Read the message
        channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);

        Console.ReadKey();
    }
}