namespace LibraryManagement.Services.BookService
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetSingleBook(int id);
        List<Book> AddBook(Book book);
        List<Book> UpdateBook(int id, Book book);
        List<Book> DeleteBook(int id);
    }
}
