namespace net6_bread_be_tests.Models;
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

        Assert.Equal(1, bread.BreadId);
        Assert.Equal("Hello", bread.Name);
        Assert.Equal("I hate autocorrect", bread.Recipe);
        Assert.Equal("World", bread.Description);
    }
}

