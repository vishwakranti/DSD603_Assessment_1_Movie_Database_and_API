using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSD603_Asseessment_1_Movie_Database_and_API.Data;
using DSD603_Asseessment_1_Movie_Database_and_API.Models;

namespace DSD603_Asseessment_1_Movie_Database_and_API.Controllers
{
    [Route("api/[controller] / [action]")]
    [ApiController]
    public class Movies1Controller : ControllerBase, IMovies1Controller
    {
        private readonly ApplicationDbContext _context;

        public Movies1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies1
        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movies1/5

        [HttpGet("GetMovie/{id}")]
        //[Route("GetMovie")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var movie = await _context.Movie.Include(x => x.Casts)
                                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(Guid id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
