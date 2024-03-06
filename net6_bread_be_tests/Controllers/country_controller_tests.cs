﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using net6_bread_be.Controllers;
using net6_bread_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net6_bread_be;

public class CountryControllerTests
{
    [Fact]
    public async Task GetAllCountries_ReturnAllCountries_WithInMemoryDatabse()
    {
        //Arrange
        var dbName = $"TestDatabase_{Guid.NewGuid()}";
        var options = new DbContextOptionsBuilder<CountryTrackerContext>().UseInMemoryDatabase(databaseName: dbName).Options;

        //Add Seeded data into the InMemory db
        using (var context = new CountryTrackerContext(options))
        {
            context.Countries.Add(new Country { CountryId = 1, Name = "Scotland", Description = "Land of the Scots" });
            context.Countries.Add(new Country { CountryId = 2, Name = "America", Description = "Land of the Free" });
            await context.SaveChangesAsync();
        }

        using (var context = new CountryTrackerContext(options))
        {
            var controller = new CountryController(context);

            //Act
            var result = await controller.GetAllCountries();

            //Assert - Making sure that the result isn't null
            Assert.NotNull(result);

            // Then check the ActionResult type
            var actionResult = Assert.IsAssignableFrom<ActionResult<IEnumerable<Country>>>(result);
            Assert.NotNull(actionResult.Result);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var countries = Assert.IsAssignableFrom<IEnumerable<Country>>(okResult.Value);

            //Now we can assert the specific details about the countries
            Assert.Equal(2, countries.Count());
            Assert.Collection(countries,
                country => Assert.Equal("Scotland", country.Name),
                Country => Assert.Equal("America", Country.Name));
        }
    }
}