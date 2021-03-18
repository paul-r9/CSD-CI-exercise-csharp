using BookInfoProvider;
using Moq;
using System;
using Xunit;

namespace ISBN.Tests
{
    public class ISBN13Test
    {

        Mock<IBookInfoProvider> _bookInfoProvider = new Mock<IBookInfoProvider>();
        [Fact]
        public void ValidateISBN_WithSpacesAndHyphens()
        {
            //Arrange
            var testIsbn13 = "978-0-13 149505-0";
            BookInfo testBook = new BookInfo("BookTitle", "Matt Baus", "124", testIsbn13.Replace(" ", "").Replace("-", ""));
            _bookInfoProvider.Setup(x => x.retrieve(It.IsAny<string>())).Returns(testBook);
            ISBNFinder sut = new ISBNFinder(_bookInfoProvider.Object);

            //Act
            BookInfo result = sut.lookup(testIsbn13);

            //Assert
            Assert.Equal(testBook.Title , result.Title);
        }

        [Fact]
        public void ValidateCheckSum_Fails()
        {
            //Arrange
            string testIsbn13 = "123456789012";
            ISBNFinder sut = new ISBNFinder(_bookInfoProvider.Object);

            //Act
            bool result = sut.ValidateCheckSum13(testIsbn13);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateCheckSum_Passes()
        {
            //Arrange
            string testIsbn13 = "9780131495050";
            ISBNFinder sut = new ISBNFinder(_bookInfoProvider.Object);

            //Act
            bool result = sut.ValidateCheckSum13(testIsbn13);

            //Assert
            Assert.True(result);
        }
    }
}
