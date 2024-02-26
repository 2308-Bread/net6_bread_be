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
}
// This is start of GPT code below
//{
//    public class CountryTests
//    {
//        [Fact]
//        public void ValidModelShouldPassValidation()
//        {
//            // Arrange
//            var country = new Country
//            {
//                CountryId = 1,
//                Name = "Valid Name",
//                Description = "Valid Description"
//            };

//            // Act
//            var validationContext = new ValidationContext(country, serviceProvider: null, items: null);
//            var validationResults = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(country, validationContext, validationResults, validateAllProperties: true);

//            // Assert
//            Assert.True(isValid);
//            Assert.Empty(validationResults);
//        }

//        [Fact]
//        public void ModelWithInvalidNameShouldFailValidation()
//        {
//            // Arrange
//            var country = new Country
//            {
//                CountryId = 1,
//                Name = "", // Invalid: Empty Name
//                Description = "Valid Description"
//            };

//            // Act
//            var validationContext = new ValidationContext(country, serviceProvider: null, items: null);
//            var validationResults = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(country, validationContext, validationResults, validateAllProperties: true);

//            // Assert
//            Assert.False(isValid);
//            Assert.Single(validationResults);
//            Assert.Equal("Name is require", validationResults[0].ErrorMessage);
//        }

//        [Fact]
//        public void ModelWithInvalidDescriptionShouldFailValidation()
//        {
//            // Arrange
//            var country = new Country
//            {
//                CountryId = 1,
//                Name = "Valid Name",
//                Description = "" // Invalid: Empty Description
//            };

//            // Act
//            var validationContext = new ValidationContext(country, serviceProvider: null, items: null);
//            var validationResults = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(country, validationContext, validationResults, validateAllProperties: true);

//            // Assert
//            Assert.False(isValid);
//            Assert.Single(validationResults);
//            Assert.Equal("Description is required", validationResults[0].ErrorMessage);
//        }
//    }
//}
