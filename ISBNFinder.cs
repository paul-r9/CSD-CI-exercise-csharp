using BookInfoProvider;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        protected ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo Lookup(string isbn) {
            
            // remove hyphens & spaces
            
            // guard clauses
            // if it's 10 digits
                // call a new method 10digit stuff
                // handle 10 digit checksum validation
            // else 
            // handle 13 digit checksum validation
            // else it's not a 10 or digit number - null case
            
            // checksum is valid, do the lookup and return
            
            if (isbn.Length != 10) {
                BookInfo badIsbn = new BookInfo("ISBN must be 10 characters in length");
                return badIsbn;
            }

            BookInfo bookInfo = isbnService.Retrieve(isbn);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }
    }
}