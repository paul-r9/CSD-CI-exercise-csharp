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
        [Fact]
        public void ISBN_WithSpaces_ReturnsValidBookInfo()
        {
            //Arrange
            string ISBNWithSpaces = "978 0 131 49505 0";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(ISBNWithSpaces);

            //Assert
            Assert.Equal("xUnit Test Patterns", actual.Title);
        }
    }
}
