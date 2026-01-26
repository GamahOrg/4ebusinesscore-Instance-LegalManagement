using _4EPlatform.Application.Features.SessionNote.Command.Delete;
using _4EPlatform.Application.Features.SessionNoteFeatures.Command.Post;
using _4EPlatform.Application.Features.SessionNote.Command.Put;
using _4EPlatform.Application.Features.SessionNote.Query.GetById;
using _4EPlatform.Application.Features.SessionNoteFeatures.Command.Post.DTO;
using _4EPlatform.Application.Features.SessionNoteFeatures.Command.Put.DTO;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.SessionNote
{
    public class SessionNoteController : BaseController
    {
        private readonly IMediator _mediator;
        public SessionNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Post
        [HttpPost]
        public Task<ResponseDTO> PostSessionNote([FromForm] PostSessionNoteDto command)
        {
            return _mediator.Send(new PostSessionNoteCommand
            {
                PostSessionNoteDto = command
            });
        }
        #endregion
        #region Put
        [HttpPut("PutSessionNote/{Id}")]
        public Task<ResponseDTO> PutSessionNote(Guid Id, [FromForm] PutSessionNoteDto command)
        {
            return _mediator.Send(new PutSessionNoteCommand
            {
                Id = Id,
                PutSessionNoteDto = command
            });
        }
        #endregion
        #region Delete
        [HttpDelete("DeleteSessionNote/{Id}")]
        public async Task<ResponseDTO> DeleteSessionNote(Guid Id, Guid CauseId)
        {
            return await _mediator.Send(new DeleteSessionNoteCommand
            {
                Id = Id, 
                CauseId = CauseId
            });
        }
        #endregion
        #region Get
        [HttpGet("GetSessionNoteById/{Id}")]
        public async Task<ResponseDTO> GetSessionNoteById(Guid Id)
        {
            return await _mediator.Send(new GetSessionNoteByIdQuery
            {
                Id = Id
            });
        }
        #endregion
    }
}
