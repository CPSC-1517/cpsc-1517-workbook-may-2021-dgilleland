using System;
using FluentAssertions;
using Topic;
using Xunit;

namespace Topic_Specs
{
    public class Fraction_Must
    {
        [Fact]
        public void Correctly_Store_Numerator()
        {
            // Arrange
            int givenNumerator = 10, givenDenominator = 20;
            Fraction sut = new Fraction(givenNumerator, givenDenominator);

            // Act
            int actual = sut.Numerator;

            // Assert
            actual.Should().Be(givenNumerator);
        }

        [Fact]
        public void Correctly_Store_Denominator()
        {
            // Arrange
            int givenNumerator = 10, givenDenominator = 20;
            Fraction sut = new Fraction(givenNumerator, givenDenominator);

            // Act
            int actual = sut.Denominator;

            // Assert
            actual.Should().Be(givenDenominator);
        }

        [Fact]
        public void Express_Fraction_Value_As_Text()
        {
            // Arrange
            int givenNumerator = 10, givenDenominator = 20;
            string expected = $"{givenNumerator}/{givenDenominator}";
            Fraction sut = new Fraction(givenNumerator, givenDenominator);

            // Act
            string actual = sut.ToString();

            // Assert
            actual.Should().Be(expected);
        }
    }
}
