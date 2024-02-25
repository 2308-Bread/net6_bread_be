using System;
namespace net6_bread_be_tests.Models;
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

		Assert.Equal(1, country.CountryId);
		Assert.Equal("Scotland", country.Name);
		Assert.Equal("Braveheart", country.Description);
	}
}

