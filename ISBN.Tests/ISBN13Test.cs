using BookInfoProvider;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ISBN.Tests
{
    public class ISBN13Test
    {
        [Fact]
        public void ISBN13_IgnoresHyphens_WhenValidISBN()
        {
            string ISBNwithoutSpaces = "9781942788331";
            string ISBNwithSpaces = "978-1-94-278833-1";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actualWithoutSpaces = sut.Lookup(ISBNwithoutSpaces);
            BookInfo actualWithSpaces = sut.Lookup(ISBNwithSpaces);

            Assert.Equal("Accelerate", actualWithoutSpaces.Title);
            Assert.Equal(actualWithSpaces.Title, actualWithoutSpaces.Title);
        }
    }
}
