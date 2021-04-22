using System;
using System.Collections.Generic;
using System.Text;
using BookInfoProvider;
using Xunit;

namespace ISBN.Tests
{
    public class ISBN13Test
    {
        [Fact]
        public void ISBN_ShorterThan13Characters_ReturnsInvalidBookInfo()
        {
            //Arrange
            string shortISBN = "12345";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(shortISBN);

            //Assert
            Assert.Equal("ISBN must be 13 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_LongerThan13Characters_ReturnsInvalidBookInfo()
        {
            string longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(longISBN);

            Assert.Equal("ISBN must be 13 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_Exactly13Characters_ReturnsBookInfo()
        {

        }


        [Fact(Skip = "skipping this test should get a Green azure build")]
        // [Fact]
        public void Failing_Test_To_Demo_CI_Automation()
        {
            // This test fails
            // Fix it and commit to trunk and observe the CI build starts and passes
            Assert.True(false, "Remove this test or change 'false' to true'");
        }

    }
}
