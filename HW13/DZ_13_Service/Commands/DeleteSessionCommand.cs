using DZ_13_Data.Entities;
using DZ_13_Data;
using Microsoft.EntityFrameworkCore;

namespace DZ_13_Service.Commands
{
    public class DeleteSessionCommand
    {
        public int SessionId { get; set; }
    }

    public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteSessionCommandHandler(ApplicationDbContext context)
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

        private async Task<Session> GetSessionAsync(int sessionId, CancellationToken cancellationToken = default)
        {
            return await _context.Sessions.SingleOrDefaultAsync(x => x.Id == sessionId);
        }
    }
}
