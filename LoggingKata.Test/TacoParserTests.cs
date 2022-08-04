using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParserTest = new TacoParser();
            var actual = tacoParserTest.Parse(line);
            Assert.Equal(expected, actual.Location.Longitude);
        }
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserTest = new TacoParser();
            var actual = tacoParserTest.Parse(line);
            Assert.Equal(expected, actual.Location.Latitude);
        }


    }
}
