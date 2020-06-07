using Xunit;

namespace Assortment.Tests
{
    public class IsEvenTest
    {
        [Fact]
        public void Even_Returns_True()
        {
        //Given
        var num = 2;
        //When
        
        //Then
        Assert.True(Even.IsEven(num));
        }

        [Fact]
        public void Odd_Returns_Fals()
        {
        //Given
        var num = 3;
        //When
        
        //Then
        Assert.False(Even.IsEven(num));
        }
    }
}