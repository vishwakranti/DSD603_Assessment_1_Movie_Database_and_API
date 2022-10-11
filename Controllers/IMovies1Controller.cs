using DSD603_Asseessment_1_Movie_Database_and_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD603_Asseessment_1_Movie_Database_and_API.Controllers
{
    public interface IMovies1Controller
    {
        Task<IActionResult> DeleteMovie(Guid id);
        Task<ActionResult<IEnumerable<Movie>>> GetAllMovies();
        Task<ActionResult<Movie>> GetMovie(Guid id);
        Task<ActionResult<Movie>> PostMovie(Movie movie);
        Task<IActionResult> PutMovie(Guid id, Movie movie);
    }
}