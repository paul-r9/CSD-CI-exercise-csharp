namespace BookInfoProvider {
    public class BookInfo {
        private readonly string _title;
        private readonly string _author;
        private readonly string _isbn10;
        private readonly string _isbn13;

        public string Title => _title;

        public string Author => _author;

        public string Isbn10 => _isbn10;

        public string Isbn13 => _isbn13;

        public BookInfo(string title, string author = null, string isbn10 = null, string isbn13 = null) {
            this._title = title;
            this._author = author;
            this._isbn10 = isbn10;
            this._isbn13 = isbn13;
        }

        public override string ToString() {
            return Title + ", " + Author + " - " + _isbn10 + ", " + _isbn13; 
        }
    }
}