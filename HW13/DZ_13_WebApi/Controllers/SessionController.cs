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
    public class SessionController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetSessions([FromServices] IRequestHandler<IList<SessionResponse>> getSessionsQuery)
        {
            return Ok(await getSessionsQuery.Handle());
        }

        [HttpGet("{sessionId}")]
        public async Task<IActionResult> GetSessionById(int sessionId, [FromServices] IRequestHandler<int, SessionResponse> getSessionByIdQuery)
        {
            return Ok(await getSessionByIdQuery.Handle(sessionId));
        }


        [HttpPost]
        public async Task<IActionResult> CreateSession([FromServices] IRequestHandler<UpsertSessionCommand, SessionResponse> upsertSession, UpsertSessionRequest request)
        {

            var sessionResponse = await upsertSession.Handle(new UpsertSessionCommand
            {
                SessionId = request.Id,
                MovieId = request.MovieId,
                RoomName = request.RoomName,
                StartDate = request.StartDate,
                StartTime = request.StartTime,
                EndTime = request.EndTime
            });

            return Ok(sessionResponse);
        }

        [HttpPut]
        [HttpPatch]
        public async Task<IActionResult> UpdateSession([FromServices] IRequestHandler<UpsertSessionCommand, SessionResponse> upsertSession, UpsertSessionRequest request, [FromServices] IRequestHandler<int, SessionResponse> getSessionByIdQuery)
        {

            if (request.Id == null || request.Id == 0)
            {
                return BadRequest("Invalid sesion ID for update.");
            }

            var existingSession = await getSessionByIdQuery.Handle(request.Id);
            if (existingSession == null)
            {
                return NotFound($"Session with ID {request.Id} not found.");
            }

            var sessionResponse = await upsertSession.Handle(new UpsertSessionCommand
            {
                SessionId = request.Id,
                MovieId = request.MovieId,
                RoomName = request.RoomName,
                StartDate = request.StartDate,
                StartTime = request.StartTime,
                EndTime = request.EndTime
            });

            return Ok(sessionResponse);
        }

        [HttpDelete("{sessionId}")]
        public async Task<IActionResult> DeleteSession(int sessionId, [FromServices] IRequestHandler<DeleteSessionCommand, bool> deleteSession)
        {
            var result = await deleteSession.Handle(new DeleteSessionCommand { SessionId = sessionId });

            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }

    }
}

