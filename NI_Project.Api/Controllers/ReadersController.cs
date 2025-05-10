using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NI_Project.Shared;

namespace NI_Project.Api.Controllers
{
    [ApiController]
    [Route("readers")]
    public class ReadersController : ControllerBase
    {
        private readonly BookDataContext _readerDataContext;

        public ReadersController(BookDataContext readerDataContext)
        {
            _readerDataContext = readerDataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Reader reader)
        {
            var existingReader = await _readerDataContext.Readers.FindAsync(reader.Id);

            if (existingReader is not null)
            {
                return Conflict();
            }

            _readerDataContext.Readers.Add(reader);
            await _readerDataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingReader = await _readerDataContext.Readers.FindAsync(id);

            if (existingReader is null)
            {
                return NotFound();
            }

            _readerDataContext.Readers.Remove(existingReader);
            await _readerDataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Reader>>> GetAll()
        {
            var readers = await _readerDataContext.Readers.ToListAsync();
            return Ok(readers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reader>> Get(string id)
        {
            var reader = await _readerDataContext.Readers.FindAsync(id);

            if (reader is null)
            {
                return NotFound();
            }

            return Ok(reader);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Reader reader)
        {
            if (id != reader.Id)
            {
                return BadRequest();
            }

            var oldReader = await _readerDataContext.Readers.FindAsync(id);

            if (oldReader is null)
            {
                return NotFound();
            }

            oldReader.Name = reader.Name;
            oldReader.Address = reader.Address;
            oldReader.BirthDate = reader.BirthDate;

            _readerDataContext.Readers.Update(oldReader);
            await _readerDataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
