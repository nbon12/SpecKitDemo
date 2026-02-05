using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SpecKitDemoApi.Models;
using Xunit;

namespace integration.Controllers;

public class UsersControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public UsersControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetUsers_ReturnsOk_WithUserList()
    {
        // Act
        var response = await _client.GetAsync("/api/users");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var users = await response.Content.ReadFromJsonAsync<List<User>>();
        users.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUsers_ReturnsJsonContentType()
    {
        // Act
        var response = await _client.GetAsync("/api/users");

        // Assert
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }
}

