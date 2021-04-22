using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ISBN.Tests
{
    public class ISBNInputValidatorTest
    {
        [Fact]
        public void Returns_passed_in_input()
        {
            var input = "input";

            var sut = ISBNInputValidator.Filter(input);

            Assert.Equal(input, sut);
        }
    }
}
