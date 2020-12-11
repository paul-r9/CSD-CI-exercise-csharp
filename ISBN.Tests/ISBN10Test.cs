using System;
using BookInfoProvider;
using Xunit;

namespace ISBN {
    public class ISBN10Test {
        [Fact]
        public void ISBN_ShorterThan10Characters_ReturnsInvalidBookInfo() {
            //Arrange
            string shortISBN = "12345";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(shortISBN);
            
            //Assert
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_LongerThan10Characters_ReturnsInvalidBookInfo() {
            string longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(longISBN);
            
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_BookAvailableFromFinder() {
            String unknownISBN = "0553562614";
            
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);
            
            Assert.Equal("Title not found", actual.Title);
        }

        [Fact]
        public void ISBN_BookFound() {
            string ISBN = "0321146530";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(ISBN);

            BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void ISBN_X_Out_OF_Place()
        {
            String unknownISBN = "12345678X9";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);

            Assert.Equal("ISBN has an X out of place", actual.Title);
        }

        [Fact]
        public void ISBN_Invalid_Characters()
        {
            String unknownISBN = "ABCDEFGHIJK";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);

            Assert.Equal("ISBN using invalid characters", actual.Title);
        }

        [Fact]
        public void ISBN_WrongChecksum()
        {
            string wrongISBN = "0478084523";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(wrongISBN);

            Assert.Equal("ISBN has wrong checksum", actual.Title);
        }

        //[Fact]
        //public void Failing_Test_To_Demo_CI_Automation() {
        //    // This test fails
        //    // Fix it and commit to trunk and observe the CI build starts and passes
        //    Assert.True(false, "Remove this test or change 'false' to true'");
        //}
    }
}