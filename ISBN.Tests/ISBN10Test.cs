using System;
using BookInfoProvider;
using Xunit;

namespace ISBN
{
    public class ISBN10Test
    {
        [Fact]
        public void ISBN_ShorterThan10Characters_ReturnsInvalidBookInfo()
        {
            //Arrange
            string shortISBN = "12345";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(shortISBN);

            //Assert
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_LongerThan10Characters_ReturnsInvalidBookInfo()
        {
            string longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(longISBN);

            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_BookAvailableFromFinder()
        {
            String unknownISBN = "0553562614";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);

            Assert.Equal("Title not found", actual.Title);
        }

        [Fact]
        public void ISBN_BookFound()
        {
            string ISBN = "0321146530";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(ISBN);

            BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530",
                "9780321146533");
            Assert.Equal(expected.ToString(), actual.ToString());
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