using BookInfoProvider;
using System.Linq;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        public ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo lookup(string ISBN) {

            ISBN = ISBN.Replace("-","").Replace(" ", "");

            if (ISBN.Length != 10 && ISBN.Length != 13)
                return new BookInfo("ISBN must be 10 or 13 characters in length");

            BookInfo bookInfo = isbnService.retrieve(ISBN);
            
            if (null == bookInfo)
                return new BookInfo("Title not found");
            
            return bookInfo;
        }

        public bool ValidateCheckSum13(string code)
        {
            code = code.Replace("-", "").Replace(" ", "");
            if (code.Length != 13) return false;
            int sum = 0;
            foreach (var (index, digit) in code.Select((digit, index) => (index, digit)))
            {
                if (char.IsDigit(digit)) sum += (digit - '0') * (index % 2 == 0 ? 1 : 3);
                else return false;
            }
            return sum % 10 == 0;
        }
    }
}