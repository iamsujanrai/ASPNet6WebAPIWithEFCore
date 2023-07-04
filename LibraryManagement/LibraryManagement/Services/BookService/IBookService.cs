namespace LibraryManagement.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book>? GetSingleBook(int id);
        Task<List<Book>> AddBook(Book book);
        Task<List<Book>>? UpdateBook(int id, Book book);
        Task<List<Book>>? DeleteBook(int id);
    }
}
