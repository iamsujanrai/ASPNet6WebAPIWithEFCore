using LibraryManagement.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var result = await _bookService.GetAllBooks();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetSingleBook(int id)
        {
            var result = await _bookService.GetSingleBook(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            var result = await _bookService.AddBook(book);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book book)
        {
            var result = await _bookService.UpdateBook(id, book);
            if (result is null)
                return NotFound("Book not found in library.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook (int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (result is null)
                return NotFound("Book not found in library.");

            return Ok(result);
        }
    }
}
