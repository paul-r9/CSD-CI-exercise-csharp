using BookInfoProvider;
using Xunit;

namespace ISBN
{
    public class ISBN13Test
    {
        [Fact]
        public void ISBN13_BookFound()
        {
            string ISBN13 = "9780321146533";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.Lookup(ISBN13);

            BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530",
                "9780321146533");
            Assert.Equal(expected.ToString(), actual.ToString());
        }
    }
}