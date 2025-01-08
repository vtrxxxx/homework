using Microsoft.AspNetCore.Mvc;
using DZ_13_Contract.Requests;
using DZ_13_Contract.Responses;
using DZ_13_Service.Commands;
using DZ_13_Service;

namespace DZ_13_WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetMovies([FromServices] IRequestHandler<IList<MovieResponse>> getMoviesQuery)
        {
            return Ok(await getMoviesQuery.Handle());
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieById(int movieId, [FromServices] IRequestHandler<int, MovieResponse> getMovieByIdQuery)
        {
            return Ok(await getMovieByIdQuery.Handle(movieId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromServices] IRequestHandler<UpsertMovieCommand, MovieResponse> upsertMovie, UpsertMovieRequest request)
        {

            var movieResponse = await upsertMovie.Handle(new UpsertMovieCommand
            {
                Title = request.Title,
                Director = request.Director,
                Genre = request.Genre,
                Description = request.Description
            });

            return Ok(movieResponse);
        }

        [HttpPut]
        [HttpPatch]
        public async Task<IActionResult> UpdateMovie([FromServices] IRequestHandler<UpsertMovieCommand, MovieResponse> upsertMovie, UpsertMovieRequest request, [FromServices] IRequestHandler<int, MovieResponse> getMovieByIdQuery)
        {

            if (request.Id == null || request.Id == 0)
            {
                return BadRequest("Invalid movie ID for update.");
            }

            var existingMovie = await getMovieByIdQuery.Handle(request.Id);
            if (existingMovie == null)
            {
                return NotFound($"Movie with ID {request.Id} not found.");
            }

            var movieResponse = await upsertMovie.Handle(new UpsertMovieCommand
            {
                Id = request.Id,
                Title = request.Title,
                Director = request.Director,
                Genre = request.Genre,
                Description = request.Description
            });

            return Ok(movieResponse);
        }


        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId, [FromServices] IRequestHandler<DeleteMovieCommand, bool> deleteMovie)
        {
            var result = await deleteMovie.Handle(new DeleteMovieCommand { MovieId = movieId });

            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}