using BookInfoProvider;
using System;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        protected ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        

        public BookInfo Lookup(string isbn) {

            isbn = ReturnCleanupISBN(isbn);

            if (isbn.Length != 10 && isbn.Length != 13) {
                BookInfo badIsbn = new BookInfo("ISBN must be 10 or 13 characters in length");
                return badIsbn;
            }

            BookInfo bookInfo = isbnService.Retrieve(isbn);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }

        private string ReturnCleanupISBN(string isbn)
        {
            return isbn.Replace(" ", "");
        }
    }
}