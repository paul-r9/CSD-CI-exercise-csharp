using BookInfoProvider;
using Xunit;

namespace ISBN
{
    public class ISBN13Test
    {
        [Theory]
        [InlineData("978 0 131 49505 0")]
        [InlineData("978-0-131-49505-0")]
        public void ISBN_Sanitize_And_ReturnsValidBookInfo(string unsanitizeISBN)
        {
            //Arrange
            
            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(unsanitizeISBN);

            //Assert
            Assert.Equal("xUnit Test Patterns", actual.Title);
        } 
        
        
        [Fact]
        public void ISBN_12_ReturnsValidBookInfo()
        {
            //Arrange
            string isbnWith12 = "123456789012";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(isbnWith12);

            //Assert
            Assert.Equal("ISBN must be 10 or 13 characters in length", actual.Title);
        }
    }
}
