namespace LibraryManagement.Services.BookService
{
    public class BookService : IBookService
    {
        private static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Name = "Ikigai",
                Description = "This is japanese book",
                Price = 100,
            },
            new Book
            {
                Id = 2,
                Name = "Think like a monk",
                Description = "Book by Jay Shetty",
                Price = 200,
            }
        };

        public List<Book> AddBook(Book book)
        {
            books.Add(book);
            return books;
        }

        public List<Book> DeleteBook(int id)
        {
            var foundBook = books.Find(x => x.Id == id);
            if (foundBook is null)
                return null;

            books.Remove(foundBook);
            return books;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetSingleBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            if (book is null)
                return null;

            return book;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            var foundBook = books.Find(x => x.Id == id);
            if (foundBook is null)
                return null;

            foundBook.Name = book.Name;
            foundBook.Description = book.Description;
            foundBook.Price = book.Price;

            return books;
        }
    }
}
