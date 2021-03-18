using System;
using BookInfoProvider;
using Xunit;

namespace ISBN
{
    
    public class ISBN13Test
    {
        [Fact]
        public void HappyPathCleanISBN13_Test()
        {
            string ISBN13 = "9780201485677";
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(ISBN13);

            BookInfo expected = new BookInfo("Refactoring", "Martin Fowler", "0201485672", "9780201485677");
            Assert.Equal(expected.ToString(), actual.ToString());
        }
    }
}