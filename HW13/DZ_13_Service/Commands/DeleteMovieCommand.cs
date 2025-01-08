using DZ_13_Data.Entities;
using DZ_13_Data;
using Microsoft.EntityFrameworkCore;

namespace DZ_13_Service.Commands
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
    }

    public class DeleteMovieCommandHandler : IRequestHandler<DeleteSessionCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteMovieCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteSessionCommand request)
        {
            var session = await GetSessionAsync(request.SessionId);

            if (session != null)
            {
                _context.Remove(session);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        private async Task<Movie> GetSessionAsync(int sessionId, CancellationToken cancellationToken = default)
        {
            return await _context.Movies.SingleOrDefaultAsync(x => x.Id == sessionId);
        }
    }
}
