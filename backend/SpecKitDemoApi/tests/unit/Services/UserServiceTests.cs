using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SpecKitDemoApi.Data;
using SpecKitDemoApi.Models;
using SpecKitDemoApi.Services;
using Xunit;

namespace unit.Services;

public class UserServiceTests
{
    [Fact]
    public async Task GetUsers_ReturnsAllUsers_WhenUsersExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new ApplicationDbContext(options);
        
        // Add test users
        context.Users.AddRange(
            new User { Id = 1, Username = "johndoe", Email = "john@example.com" },
            new User { Id = 2, Username = null, Email = "jane@example.com" },
            new User { Id = 3, Username = "bobsmith", Email = "bob@example.com" }
        );
        await context.SaveChangesAsync();

        var service = new UserService(context);

        // Act
        var result = await service.GetUsersAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().Contain(u => u.Email == "john@example.com" && u.Username == "johndoe");
        result.Should().Contain(u => u.Email == "jane@example.com" && u.Username == null);
        result.Should().Contain(u => u.Email == "bob@example.com" && u.Username == "bobsmith");
    }

    [Fact]
    public async Task GetUsers_ReturnsEmptyList_WhenNoUsersExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new ApplicationDbContext(options);
        var service = new UserService(context);

        // Act
        var result = await service.GetUsersAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}

