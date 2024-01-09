using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Xunit;
using MessagingService.Model;

public class MessageApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public MessageApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAllMessages_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/message/getall");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task AddMessage_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();
        var message = new Message
        {
            UserId = 1, // Provide a valid user ID
            Body = "This is a sample message body."
        };

        // Act
        var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/message/add", content);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetMessageById_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();
        var messageId = 3; // Provide a valid message ID

        // Act
        var response = await client.GetAsync($"/message/{messageId}");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    //[Fact]
    //public async Task DeleteMessage_ReturnsSuccessStatusCode()
    //{
    //    // Arrange
    //    var client = _factory.CreateClient();
    //    var messageIdToDelete = 2; // Provide a valid message ID to delete

    //    // Act
    //    var response = await client.GetAsync($"/message/delete?id={messageIdToDelete}");

    //    // Assert
    //    response.EnsureSuccessStatusCode();
    //}
}
