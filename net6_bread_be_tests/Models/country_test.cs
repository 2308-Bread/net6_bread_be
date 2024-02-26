using System;
namespace net6_bread_be_tests.Models;
using System.ComponentModel.DataAnnotations;

using System.Threading;
using net6_bread_be.Models;

public class CountryTests
{
	[Fact]
	public void CountryProperties()
	{
		Country country = new Country
		{
			CountryId = 1,
            Name = "Scotland",
            Description = "Braveheart"
        };

        var validationContext = new ValidationContext(country, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(country, validationContext, validationResults, validateAllProperties: true);

        Assert.Equal(1, country.CountryId);
		Assert.Equal("Scotland", country.Name);
		Assert.Equal("Braveheart", country.Description);

		Assert.True(isValid);
		Assert.Empty(validationResults);
	}

	//Sad Path testing

	[Fact]
	public void CountrySadPathName()
	{
		Country country = new Country
		{
			CountryId = 1,
			Name = "",
			Description = "Words"
		};

        var validationContext = new ValidationContext(country, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(country, validationContext, validationResults, validateAllProperties: true);

        Assert.False(isValid);
        Assert.Single(validationResults);
        Assert.Equal("Name is required", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void CountrySadPathDescription()
    {
        Country country = new Country
        {
            CountryId = 1,
            Name = "Land",
            Description = ""
        };

        var validationContext = new ValidationContext(country, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(country, validationContext, validationResults, validateAllProperties: true);

        Assert.False(isValid);
        Assert.Single(validationResults);
        Assert.Equal("Description is required", validationResults[0].ErrorMessage);
    }
}

