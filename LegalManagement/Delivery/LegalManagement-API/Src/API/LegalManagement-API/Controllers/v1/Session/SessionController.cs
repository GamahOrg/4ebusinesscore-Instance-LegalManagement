
using _4EPlatform.Application.Features.SessionFeature.Command.Delete;
using _4EPlatform.Application.Features.SessionFeature.Command.Post;
using _4EPlatform.Application.Features.SessionFeature.Command.Put;
using _4EPlatform.Application.Features.SessionFeature.Command.Put.DTO;
using _4EPlatform.Application.Features.SessionFeature.Query.GetActiveSession;
using _4EPlatform.Application.Features.SessionFeature.Query.GetAll;
using _4EPlatform.Application.Features.SessionFeature.Query.GetAllSessions;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.Session
{

    public class SessionController : BaseController
    {
        private readonly IMediator _mediator;

        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region post 
        [HttpPost("PostSession")]
        public async Task<ResponseDTO> PostSession([FromForm] PostSessionCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
        #region put 
        [HttpPut("PutSession")]
        public async Task<ResponseDTO> PutSession(Guid Id, [FromForm] PutSessionDto dto)
        {
            return await _mediator.Send(new PutSessionCommand { Id = Id, PutSessionDto =dto });
        }
        #endregion
        #region delete 
        [HttpDelete("DeleteSession/{Id}")]
        public async Task<ResponseDTO> DeleteSession(Guid Id, Guid causeId)
        {
            return await _mediator.Send(new DeleteSessionCommand { Id = Id, CauseId = causeId });
        }
        #endregion
        //#region Get
        //[HttpGet("GetSessionById/{Id}")]
        //public async Task<ResponseDTO> GetSessionById(Guid Id)
        //{
        //    return await _mediator.Send(new GetSessionByIdQuery { Id = Id });
        //}
        //#endregion
        #region GetAll 
        [HttpGet("GetAllSessions")]
        public async Task<ResponseDTO> GetAllSessions([FromQuery] GetAllSessionsCommand command)
            => await _mediator.Send(command);
        #endregion


        [HttpGet("GetActiveSession/{CauseStageId}")]
        public async Task<ResponseDTO>GetActiveSession (Guid CauseStageId) => await _mediator
            .Send(new GetSessionQuery { CauseStageId = CauseStageId });

        #region New GetSessions
        [HttpGet("GetSessions")]
        public async Task<ResponseDTO> GetASessions([FromQuery] GetSessionsCommand command)
            => await _mediator.Send(command);
        #endregion
    }
}
