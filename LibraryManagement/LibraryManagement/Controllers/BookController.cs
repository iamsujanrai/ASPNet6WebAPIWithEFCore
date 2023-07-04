using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
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

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetSingleBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            if (book is null)
                return NotFound("Requested book not found in library");
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            books.Add(book);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book book)
        {
            var foundBook = books.Find(x => x.Id == id);
            if (foundBook is null)
                return NotFound("Requested book not found in library");
            foundBook.Name = book.Name;
            foundBook.Description = book.Description;
            foundBook.Price = book.Price;

            return Ok(books);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook (int id)
        {
            var foundBook = books.Find(x => x.Id == id);
            if (foundBook is null)
                return NotFound("Requested book not found in library");
            books.Remove(foundBook);
            return Ok(books);
        }
    }
}
