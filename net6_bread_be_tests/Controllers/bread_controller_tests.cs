using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using net6_bread_be.Controllers;
using net6_bread_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net6_bread_be;

public class BreadControllerTests
{
    [Fact]
    public async Task GetAllBreads_ReturnsAllBreads_WithInMemoryDatabase()
    {
        // Arrange
        var dbName = $"TestDatabase_{Guid.NewGuid()}"; // Ensure a unique database name to avoid conflicts
        var options = new DbContextOptionsBuilder<BreadTrackerContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        // Insert seed data into the in-memory database
        using (var context = new BreadTrackerContext(options))
        {
            context.Breads.Add(new Bread { BreadId = 1, Name = "Sourdough", Recipe = "Recipe for Sourdough", Description = "Description of Sourdough", CountryId = 1 });
            context.Breads.Add(new Bread { BreadId = 2, Name = "Baguette", Recipe = "Recipe for Baguette", Description = "Description of Baguette", CountryId = 2 });
            await context.SaveChangesAsync();
        }

        // Use a separate instance of the context to run the test
        using (var context = new BreadTrackerContext(options))
        {
            var controller = new BreadController(context);

            // Act
            var result = await controller.GetAllBreads();

            // Assert - First ensure the result is not null
            Assert.NotNull(result);

            // Then check the ActionResult type
            var actionResult = Assert.IsAssignableFrom<ActionResult<IEnumerable<Bread>>>(result);
            Assert.NotNull(actionResult.Result); // Ensure you actually got a result

            // Check for OkObjectResult and extract the value
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var breads = Assert.IsAssignableFrom<IEnumerable<Bread>>(okResult.Value); // Use IsAssignableFrom for more flexibility

            // Now we can assert the specific details about the breads returned
            Assert.Equal(2, breads.Count());
            Assert.Collection(breads,
                bread => Assert.Equal("Sourdough", bread.Name),
                bread => Assert.Equal("Baguette", bread.Name));
        }
    }
    [Fact]
    public async Task GetBreadById_ReturnsBread_WhenBreadExists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BreadTrackerContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabaseForGetById")
            .Options;

        // Seed data
        var testBreadId = 1;
        using (var context = new BreadTrackerContext(options))
        {
            context.Breads.Add(new Bread { BreadId = testBreadId, Name = "Test Bread", Recipe = "Test Recipe", Description = "Test Description", CountryId = 1 });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new BreadTrackerContext(options))
        {
            var controller = new BreadController(context);
            var result = await controller.GetBreadById(testBreadId);

            var actionResult = Assert.IsType<ActionResult<Bread>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var bread = Assert.IsType<Bread>(okResult.Value);
            Assert.Equal(testBreadId, bread.BreadId);
        }
    }
    [Fact]
    public async Task GetBreadById_ReturnsNotFound_WhenBreadDoesNotExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BreadTrackerContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabaseForGetByIdNotFound")
            .Options;

        // No need to seed data for this test

        // Act & Assert
        using (var context = new BreadTrackerContext(options))
        {
            var controller = new BreadController(context);
            var result = await controller.GetBreadById(999); // Using an ID unlikely to exist

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }


}
