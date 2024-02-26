namespace net6_bread_be_tests.Models;

using System.ComponentModel.DataAnnotations;
using net6_bread_be.Models;

public class BreadTests
{
    [Fact]
    public void BreadProperties()
    {
        Bread bread = new Bread
        {
            BreadId = 1,
            Name = "Hello",
            Recipe = "I hate autocorrect",
            Description = "World"
        };

        var validationContext = new ValidationContext(bread, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(bread, validationContext, validationResults, validateAllProperties: true);


        Assert.Equal(1, bread.BreadId);
        Assert.Equal("Hello", bread.Name);
        Assert.Equal("I hate autocorrect", bread.Recipe);
        Assert.Equal("World", bread.Description);

        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

    //Sad Path Testing

    [Fact]
    public void BreadSadPathName()
    {
        Bread bread = new Bread
        {
            BreadId = 1,
            Name = "",
            Recipe = "Work",
            Description = "Love"
        };

        var validationContext = new ValidationContext(bread, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(bread, validationContext, validationResults, validateAllProperties: true);

        Assert.Equal(1, bread.BreadId);
        Assert.Equal("Work", bread.Recipe);
        Assert.Equal("Love", bread.Description);

        Assert.False(isValid);
        Assert.Single(validationResults);
        Assert.Equal("Name is required", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void BreadSadPathRecipe()
    {
        Bread bread = new Bread
        {
            BreadId = 1,
            Name = "You",
            Recipe = "",
            Description = "Love"
        };

        var validationContext = new ValidationContext(bread, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(bread, validationContext, validationResults, validateAllProperties: true);

        Assert.Equal(1, bread.BreadId);
        Assert.Equal("You", bread.Name);
        Assert.Equal("Love", bread.Description);

        Assert.False(isValid);
        Assert.Single(validationResults);
        Assert.Equal("Recipe is required", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void BreadSadPathDescription()
    {
        Bread bread = new Bread
        {
            BreadId = 1,
            Name = "You",
            Recipe = "Work",
            Description = ""
        };

        var validationContext = new ValidationContext(bread, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(bread, validationContext, validationResults, validateAllProperties: true);

        Assert.Equal(1, bread.BreadId);
        Assert.Equal("You", bread.Name);
        Assert.Equal("Work", bread.Recipe);

        Assert.False(isValid);
        Assert.Single(validationResults);
        Assert.Equal("Description is required", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void BreadSadPathId()
    {
        Bread bread = new Bread
        {
            Name = "You",
            Recipe = "Work",
            Description = "Words"
        };

        Bread bread2 = new Bread
        {
            Name = "Bread2",
            Recipe = "Love",
            Description = "spelt wrong"
        };

        var validationContext = new ValidationContext(bread, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(bread, validationContext, validationResults, validateAllProperties: true);

        //not passing it an explicit value auto assigns 0 to the Id
        Assert.Equal(0, bread.BreadId);
        //Assert.Equal(1, bread2.BreadId);

        Assert.Equal("You", bread.Name);
        Assert.Equal("Work", bread.Recipe);
        Assert.Equal("Words", bread.Description);

        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
}
