using System;
using BookInfoProvider;
using Xunit;

namespace ISBN
{

   public class ISBN13Test
   {
      const string invalidIsbnErrorMessage = "ISBN is invalid";

      [Fact]
      public void ISBN_ShorterThan13Characters_ReturnsInvalidBookInfo()
      {
         //Arrange
         string shortISBN = "12345";

         //Act
         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(shortISBN);

         //Assert
         Assert.Equal(invalidIsbnErrorMessage, actual.Title);
      }

      [Fact]
      public void ISBN_LongerThan13Characters_ReturnsInvalidBookInfo()
      {
         string longISBN = "123456789ABCEDF";

         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(longISBN);

         Assert.Equal(invalidIsbnErrorMessage, actual.Title);
      }

      [Fact]
      public void ISBN_BookAvailableFromFinder()
      {
         String unknownISBN = "978-0545790352";

         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(unknownISBN);

         Assert.Equal("Title not found", actual.Title);
      }

      [Fact]
      public void ISBN_BookFound()
      {
         string ISBN = "9780321146533";

         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(ISBN);

         BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");
         Assert.Equal(expected.ToString(), actual.ToString());
      }

      [Fact]
      public void Failing_Test_To_Demo_CI_Automation()
      {
         // This test fails
         // Fix it and commit to trunk and observe the CI build starts and passes
         //Assert.True(false, "Remove this test or change 'false' to true'");
      }
   }
}