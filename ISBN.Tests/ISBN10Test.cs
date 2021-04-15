using System;
using BookInfoProvider;
using Xunit;

namespace ISBN
{
    public class ISBN10Test
    {
        private const string ignored = "ignored";
        private const string titleNotFound = "Title not found";
        private const string invalidISBN = "Invalid ISBN";

        [Fact]
        public void ISBN_ShorterThan10Characters_ReturnsInvalidBookInfo()
        {
            //Arrange
            string shortISBN = "12345";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(shortISBN);

            //Assert
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_LongerThan10Characters_ReturnsInvalidBookInfo()
        {
            string longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(longISBN);

            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_BookAvailableFromFinder()
        {
            String unknownISBN = "0553562614";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(unknownISBN);

            Assert.Equal("Title not found", actual.Title);
        }

        [Fact]
        public void ISBN_BookFound()
        {
            string ISBN = "0321146530";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(ISBN);

            BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530",
                "9780321146533");
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact(Skip = "skipping this test should get a Green azure build")]
        //[Fact]
        // [Fact(Skip="Enable this test to see the CI build fail")]
        public void Failing_Test_To_Demo_CI_Automation()
        {
            // This test fails
            // Fix it and commit to trunk and observe the CI build starts and passes
            Assert.True(false, "Remove this test or change 'false' to true'");
        }

        [Fact]
        public void ISBN_Invalid_Characters_Should_Return_Invalid_BI()
        {
            string ISBN = "123456789A";
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(ISBN);

            Assert.Equal(invalidISBN, actual.Title);
        }
    }
}