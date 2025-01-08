using DZ_13_Contract.Responses;
using DZ_13_Data.Entities;
using DZ_13_Data;
using DZ_13_Service;
using Microsoft.EntityFrameworkCore;


namespace DZ_13_Service.Commands
{
    public class UpsertSessionCommand
    {
        public int SessionId { get; set; }
        public int MovieId { get; set; }
        public string RoomName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Session UpsertSession()
        {
            return new Session
            {
                Id = SessionId,
                MovieId = MovieId,
                RoomName = RoomName,
                StartDate = StartDate,
                StartTime = StartTime,
                EndTime = EndTime
            };
        }
    }

    public class UpsertSessionCommandHandler : IRequestHandler<UpsertSessionCommand, SessionResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpsertSessionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SessionResponse> Handle(UpsertSessionCommand request)
        {
            var session = await GetSessionAsync(request.SessionId);

            if (session == null)
            {
                session = request.UpsertSession();
                await _context.AddAsync(session);
            }
            else
            {
                session.MovieId = request.MovieId;
                session.RoomName = request.RoomName;
                session.StartDate = request.StartDate;
                session.StartTime = request.StartTime;
                session.EndTime = request.EndTime;
            }

            await _context.SaveChangesAsync();


            return new SessionResponse
            {
                Id = session.Id,
                RoomName = session.RoomName,
                StartDate = session.StartDate,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                MovieID = session.MovieId,
            };
        }

        private async Task<Session> GetSessionAsync(int sessionId)
        {
            return await _context.Sessions.SingleOrDefaultAsync(x => x.Id == sessionId);
        }
    }
}
