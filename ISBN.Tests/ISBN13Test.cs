using BookInfoProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ISBN
{
    public class ISBN13Test
    {
        [Theory]
        [InlineData("978 0 131 49505 0")]
        [InlineData("978-0-131-49505-0")]
        public void ISBN_WithSpaces_ReturnsValidBookInfo(string ISBNWithSpaces)
        {
            //Arrange
            
            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(ISBNWithSpaces);

            //Assert
            Assert.Equal("xUnit Test Patterns", actual.Title);
        } 
    }
}
