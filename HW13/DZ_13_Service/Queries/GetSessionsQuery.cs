using DZ_13_Contract.Responses;
using DZ_13_Data;
using DZ_13_Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DZ_13_Service.Queries
{
    public class GetSessionsQueryHandler : IRequestHandler<IList<SessionResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetSessionsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<SessionResponse>> Handle()
        {
            return await _context.Sessions
               .AsNoTracking()
               .Include(session => session.Movie)  
               .Select(session => new SessionResponse
               {
                   Id = session.Id,
                   MovieID = session.MovieId, 
                   RoomName = session.RoomName,
                   StartDate = session.StartDate,
                   StartTime = session.StartTime,
                   EndTime = session.EndTime,
                   MovieResponse = new MovieResponse
                   {
                       Id = session.Movie.Id,
                       Title = session.Movie.Title,
                       Director = session.Movie.Director,
                       Genre = session.Movie.Genre,
                       Description = session.Movie.Description
                   }
               })
               .OrderByDescending(x => x.StartDate) 
               .ToListAsync();
        }
    }
}