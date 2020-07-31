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
      public void ISBN_InvalidCharacters_ReturnsInvalidIsbnError()
      {
         //Arrange
         string isbn = "978032A146533";

         //Act
         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(isbn);

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
      public void ISBN_BookNotAvailableFromFinder()
      {
         String unknownISBN = "978-0545790352";  // harry potter valid ISBN

         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(unknownISBN);

         Assert.Equal("Title not found", actual.Title);
      }

      [Fact]
      public void ISBN_BookNotAvailableFromFinder_LotsOfDashes()
      {
         String unknownISBN = "978-05-45-79-03-5-2";  // harry potter valid ISBN

         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(unknownISBN);

         Assert.Equal("Title not found", actual.Title);
      }

      [Fact]
      public void ISBN_BookNotAvailableFromFinder_LotsOfSpaces()
      {
         String unknownISBN = "9 7 80 54 57 903 5 2";  // harry potter valid ISBN

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
      public void ISBN_BookFound_Type2()
      {
         string ISBN = "978-0134757599";

         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(ISBN);

         BookInfo expected = new BookInfo("Refactoring 2nd Edition", "Martin Fowler", "0134757599", "9780134757599");
         Assert.Equal(expected.ToString(), actual.ToString());
      }

      [Fact]
      public void ISBN_InvalidChecksum()
      {
         string ISBN = "9780321146531";

         ISBNFinder sut = new ISBNFinder();
         BookInfo actual = sut.lookup13(ISBN);

         Assert.Equal(invalidIsbnErrorMessage, actual.Title);
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