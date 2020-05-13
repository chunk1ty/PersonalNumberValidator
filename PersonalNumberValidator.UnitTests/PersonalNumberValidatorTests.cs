using System;
using FluentAssertions;
using NUnit.Framework;

namespace PersonalNumberValidator.UnitTests
{
    public class Tests
    {
        private PersonalNumberValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PersonalNumberValidator();
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("     ")]
        public void IsValid_WhenNumberIsNullOrWhiteSpace_ShouldThrowsArgumentNullException(string input)
        {
            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => _validator.IsValid(input));

            // Assert
            ex.Message.Should().Contain("number");
        }

        [TestCase("123456789")]
        [TestCase("12345678901")]
        public void IsValid_WhenNumberLengthIsNot10_ShouldReturnFailureResult(string input)
        {
            // Act
            var result =  _validator.IsValid(input);

            // Assert
            result.IsSuccessful.Should().BeFalse();
            result.Error.Should().Be("Personal number should be 10 digits.");
        }

        [TestCase("a123456789")]
        [TestCase("1a23456789")]
        [TestCase("12a3456789")]
        [TestCase("123a456789")]
        [TestCase("1234a56789")]
        [TestCase("12345a6789")]
        [TestCase("123456a789")]
        [TestCase("1234567a89")]
        [TestCase("12345678a9")]
        [TestCase("123456789a")]
        [TestCase("aaaaaaaaaa")]
        public void IsValid_WhenNumberContainsLetter_ShouldReturnFailureResult(string input)
        {
            // Act
            var result = _validator.IsValid(input);

            // Assert
            result.IsSuccessful.Should().BeFalse();
            result.Error.Should().Be("Personal number should contains only digits.");
        }

        [TestCase("1253000000")]
        [TestCase("1212350000")]
        [TestCase("1252320000")]
        [TestCase("0099010000")]
        public void IsValid_WhenDateIsInvalid_ShouldReturnFailureResult(string input)
        {
            // Act
            var result = _validator.IsValid(input);

            // Assert
            result.IsSuccessful.Should().BeFalse();
            result.Error.Should().Be("Invalid date of birth.");
        }


        [TestCase("6101057500")]
        [TestCase("7501010011")]
        public void IsValid_WithInvalidNumber_ShouldReturnFailureResult(string input)
        {
            // Act
            var result = _validator.IsValid(input);

            // Assert
            result.IsSuccessful.Should().BeFalse();
            result.Error.Should().Be("Invalid Personal number.");
        }

        [TestCase(" 6101057509 ")]
        [TestCase("9406284332")]
        [TestCase("7524169268")]
        [TestCase("7501010010")]
        [TestCase("7552010005")]
        [TestCase("8032056031")]
        [TestCase("8001010008")]
        [TestCase("7552011038")]
        [TestCase("8141010016")]
        [TestCase("1007090190                                                                ")]
        [TestCase("                                                                            2710196327")]
        [TestCase("4607150510")]
        public void IsValid_WithValidNumber_ShouldReturnSuccessfulResult(string input)
        {
            // Act
            var result = _validator.IsValid(input);

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }
    }
}