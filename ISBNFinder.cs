using System;
using BookInfoProvider;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        protected ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo Lookup(string isbn)
        {
            isbn = RemoveSpacesAndHyphens(isbn);
            if (isbn.Length == 13)
            {
                return isbnService.Retrieve(isbn);
            }
            
            if (isbn.Length != 10) {
                BookInfo badIsbn = new BookInfo("ISBN must be 10 characters in length");
                return badIsbn;
            }

            if(HasInvalidCharacters(isbn))
            {
                BookInfo invalidIsbn = new BookInfo("Invalid ISBN");
                return invalidIsbn;
            }

            BookInfo bookInfo = isbnService.Retrieve(isbn);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }

        private string RemoveSpacesAndHyphens(string isbn)
        {
            return isbn.Replace("-", "").Replace(" ", "");
        }

        private bool HasInvalidCharacters(string isbn)
        {
            string isbnToValidate = isbn;
            if (isbn.EndsWith("x", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                isbnToValidate = isbn.Substring(0, isbn.Length - 2);
            }
            bool isOnlyDigits = int.TryParse(isbnToValidate, out _);
            return !isOnlyDigits;
        }
    }
}