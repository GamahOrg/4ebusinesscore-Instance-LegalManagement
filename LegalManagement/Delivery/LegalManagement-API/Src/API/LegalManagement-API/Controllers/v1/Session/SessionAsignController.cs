using _4EPlatform.Application.Features.SessionAssign.Command.Delete;
using _4EPlatform.Application.Features.SessionAssign.Command.Post;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.Session
{
    public class SessionAsignController : BaseController
    {
        private readonly IMediator _mediator;

        public SessionAsignController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region post 
        [HttpPost("PostSessionAsign/{SessionId}/{CauseId}")]
        public async Task<ResponseDTO> PostSessionAsign(Guid SessionId, Guid CauseId, [FromBody] List<SessionAsignDto> dto)
        {
            return await _mediator.Send(new PostSessionAsignCommand(SessionId, dto, CauseId));
        }
        #endregion
        #region delete 
        [HttpDelete("DeleteSessionAsign/{Id}/{CauseId}")]
        public async Task<ResponseDTO> DeleteSessionAsign(Guid Id, Guid CauseId)
        {
            return await _mediator.Send(new DeleteSessionAsignCommand(Id, CauseId));
        }
        #endregion
    }
}
