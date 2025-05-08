using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NI_Project.Shared;

namespace NI_Project.Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly BookDataContext _bookDataContext;

        public BooksController(BookDataContext bookDataContext)
        {
            _bookDataContext = bookDataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            var existingBook = await _bookDataContext.Books.FindAsync(book.Id);

            if (existingBook is not null)
            {
                return Conflict();
            }

            _bookDataContext.Books.Add(book);
            await _bookDataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingBook = await _bookDataContext.Books.FindAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            _bookDataContext.Books.Remove(existingBook);
            await _bookDataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var books = await _bookDataContext.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookDataContext.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var oldBook = await _bookDataContext.Books.FindAsync(id);

            if (oldBook is null)
            {
                return NotFound();
            }

            oldBook.Title = book.Title;
            oldBook.Author = book.Author;
            oldBook.Publisher = book.Publisher;
            oldBook.YearOfPublish = book.YearOfPublish;

            _bookDataContext.Books.Update(oldBook);
            await _bookDataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
