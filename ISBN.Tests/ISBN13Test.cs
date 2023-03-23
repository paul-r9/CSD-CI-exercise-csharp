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
            string ISBNwitoutHyphens = "9781942788331";
            string ISBNwithHyphens = "978-1-94-278833-1";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actualWithoutHyphens = sut.Lookup(ISBNwitoutHyphens);
            BookInfo actualWithHyphens = sut.Lookup(ISBNwithHyphens);

            Assert.Equal("Accelerate", actualWithoutHyphens.Title);
            Assert.Equal(actualWithHyphens.Title, actualWithoutHyphens.Title);
        }

        [Fact]
        public void ISBN13_IgnoresSpaces_WhenValidISBN()
        {
            string ISBNwithoutSpaces = "9781942788331";
            string ISBNwithSpaces = "978 1 94 278833 1";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actualWithoutSpaces = sut.Lookup(ISBNwithoutSpaces);
            BookInfo actualWithSpaces = sut.Lookup(ISBNwithSpaces);

            Assert.Equal("Accelerate", actualWithoutSpaces.Title);
            Assert.Equal(actualWithSpaces.Title, actualWithoutSpaces.Title);
        }
    }
}
