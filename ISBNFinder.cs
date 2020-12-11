using BookInfoProvider;
using System;
using System.Text.RegularExpressions;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        public ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo lookup(string ISBN) {
            ISBN = ISBN.Replace(" ", "").Replace("-", "");
            Regex re = new Regex(@"[0-9X]");
            if(!re.IsMatch(ISBN))
            {
                BookInfo badISBN = new BookInfo("ISBN using invalid characters");
                return badISBN;
            }
            
            if(!(ISBN.IndexOf("X") == 9 || ISBN.IndexOf("X") == -1))
            {
                BookInfo badISBN = new BookInfo("ISBN has an X out of place");
                return badISBN;
            }

            if (ISBN.Length != 10) {
                BookInfo badISBN = new BookInfo("ISBN must be 10 characters in length");
                return badISBN;
            }

            if (!validChecksum(ISBN))
            {
                BookInfo badISBN = new BookInfo("ISBN has wrong checksum");
                return badISBN;
            }

            BookInfo bookInfo = isbnService.retrieve(ISBN);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }

        public bool validChecksum(string ISBN)
        {
            int accumulator = 0;
            for(int i = 0; i < ISBN.Length - 1; i++)
            {
                int pos = int.Parse(ISBN[i].ToString());
                accumulator += pos * (i + 1);
            }
            accumulator %= 11;
            if(accumulator == 10)
            {
                return ISBN[ISBN.Length - 1] == 'X';
            }
            else
            {
                return ISBN[ISBN.Length - 1] == accumulator.ToString().ToCharArray()[0];
            }
        }

    }
}