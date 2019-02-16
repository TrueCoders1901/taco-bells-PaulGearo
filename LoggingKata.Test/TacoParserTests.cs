using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            
        }

        [Theory]
        [InlineData("1,1,name")]
        [InlineData("12.89,98.321, not real")]
        [InlineData("-17.58913, -100.00487, middle of no where")]
        public void ShouldParse(string str)
        {
            // TODO: Complete Should Parse

            //arange 
            TacoParser tacoParser = new TacoParser();

            //act
            var tacoBell = tacoParser.Parse(str);

            //assert
            Assert.NotNull(tacoBell);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("gooble,de,gook")]
        [InlineData("the Office, food, Chips Heart")]
        [InlineData("1234567.89,987654.321, not real")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse

            //arange 
            TacoParser tacoParser = new TacoParser();
            //act
            var tacoBell = tacoParser.Parse(str);
            //assert
            Assert.Null(tacoBell);
        }
    }
}
