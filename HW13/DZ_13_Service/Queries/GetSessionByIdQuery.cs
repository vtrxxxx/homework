using DZ_13_Contract.Responses;
using DZ_13_Data;
using DZ_13_Service;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DZ_13_Service.Queries
{
    public class GetSessionByIdQueryHandler : IRequestHandler<int, SessionResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetSessionByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SessionResponse> Handle(int sessionId)
        {
            var session = await _context.Sessions
                .AsNoTracking()
                .Include(s => s.Movie)
                .Where(s => s.Id == sessionId)
                .Select(s => new SessionResponse
                {
                    Id = s.Id,
                    MovieID = s.MovieId,
                    RoomName = s.RoomName,
                    StartDate = s.StartDate,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    MovieResponse = new MovieResponse
                    {
                        Id = s.Movie.Id,
                        Title = s.Movie.Title,
                        Director = s.Movie.Director,
                        Genre = s.Movie.Genre,
                        Description = s.Movie.Description
                    }
                })
                .SingleOrDefaultAsync();

            return session;
        }
    }
}
