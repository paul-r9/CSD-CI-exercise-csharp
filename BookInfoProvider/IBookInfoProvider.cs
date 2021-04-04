using BookInfoProvider;

namespace BookInfoProvider {

    public interface IBookInfoProvider {
        BookInfo Retrieve(string isbn);
    }
}