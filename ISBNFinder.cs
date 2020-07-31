using BookInfoProvider;

namespace ISBN
{
   public class ISBNFinder
   {
      private IBookInfoProvider isbnService = null;

      public ISBNFinder() : this(ISBNService.Instance)
      {
      }

      public ISBNFinder(IBookInfoProvider bookInfoProvider)
      {
         isbnService = bookInfoProvider;
      }

      public BookInfo lookup(string ISBN)
      {

         if (ISBN.Length != 10)
         {
            BookInfo badISBN = new BookInfo("ISBN must be 10 characters in length");
            return badISBN;
         }

         BookInfo bookInfo = isbnService.retrieve(ISBN);

         if (null == bookInfo)
         {
            return new BookInfo("Title not found");
         }

         return bookInfo;
      }

      public BookInfo lookup13(string ISBN)
      {
         
         if (!ISBN13Validator.Validate(ISBN))
         {
            BookInfo badISBN = new BookInfo("ISBN is invalid");
            return badISBN;
         }

         BookInfo bookInfo = isbnService.retrieve(ISBN);

         if (null == bookInfo)
         {
            return new BookInfo("Title not found");
         }

         return bookInfo;
      }
   }
}