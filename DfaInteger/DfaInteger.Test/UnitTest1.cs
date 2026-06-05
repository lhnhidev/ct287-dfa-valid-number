using DfaInteger.DfaInteger.Main;
using Xunit;

namespace DfaInteger.Tests;

public class IntegerDfaTests {
    [Theory]
    [InlineData("0")]          
    [InlineData("+0")]
    [InlineData("-0")]          
    [InlineData("5")]           
    [InlineData("1234567890")]  
    [InlineData("+42")]         
    [InlineData("-99")]         
    public void IsValid_WithValidInputs_ReturnsTrue(string input) {
        bool result = Integer.IsValid(input);

        Assert.True(result, $"Chuỗi '{input}' phải được coi là hợp lệ.");
    }

    [Theory]
    [InlineData(null)]        
    [InlineData("")]          
    [InlineData(" ")]         
    [InlineData("+")]         
    [InlineData("-")]         
    [InlineData("01")]        
    [InlineData("-05")]       
    [InlineData("+09")]       
    [InlineData("12a3")]      
    [InlineData("+-5")]       
    [InlineData("123-")]      
    public void IsValid_WithInvalidInputs_ReturnsFalse(string input) {
        bool result = Integer.IsValid(input);

        Assert.False(result, $"Chuỗi '{input}' phải bị từ chối.");
    }

    [Fact]
    public void TryParse_WithValidInput_ReturnsTrueAndCorrectValue() {
        string input = "-12345";
        long expectedValue = -12345L;

        bool isSuccess = Integer.TryParse(input, out long actualValue);

        Assert.True(isSuccess);
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void TryParse_WithInvalidInput_ReturnsFalseAndZero() {
        string input = "07"; 

        bool isSuccess = Integer.TryParse(input, out long actualValue);

        Assert.False(isSuccess);
        Assert.Equal(0L, actualValue); 
    }
}