namespace LibraryManagement.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> AddBook(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>?> DeleteBook(int id)
        {
            var foundBook = await _context.Books.FindAsync(id);
            if (foundBook is null)
                return null;

            _context.Books.Remove(foundBook);
            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetSingleBook(int id)
        {
            var foundBook = await _context.Books.FindAsync(id);
            if (foundBook is null)
                return null;

            return foundBook;
        }

        public async Task<List<Book>?> UpdateBook(int id, Book book)
        {
            var foundBook = await _context.Books.FindAsync(id);
            if (foundBook is null)
                return null;

            foundBook.Name = book.Name;
            foundBook.Description = book.Description;
            foundBook.Price = book.Price;

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
    }
}
