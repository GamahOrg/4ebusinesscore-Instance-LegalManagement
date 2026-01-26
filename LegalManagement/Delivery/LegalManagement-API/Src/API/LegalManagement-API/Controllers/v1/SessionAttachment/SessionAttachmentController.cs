
using _4EPlatform.Application.Features.SessionAttachment.Command.Delete;
using _4EPlatform.Application.Features.SessionAttachment.Command.Post;
using _4EPlatform.Application.Features.SessionAttachment.Query.GetSessionAttachment;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.SessionAttachment
{
    public class SessionAttachmentController :   BaseController
    {
        private readonly IMediator _mediator;

    public SessionAttachmentController(IMediator mediator)
    {
        _mediator = mediator;
    }
 
    [HttpPost("PostSessionAttachment")]
    public async Task<ResponseDTO> PostSessionAttachment([FromQuery] postSessionAttachmentCommand command)
    {
        return await _mediator.Send( command);
    }
        [HttpGet("GetSessionAttachment")]
        public async Task<ResponseDTO> GetSessionAttachment([FromQuery] GetSessionAttachmentQuery query) => await _mediator.Send(query);

  [HttpDelete("DeleteSessionAttachment")]
        public async Task<ResponseDTO> DeleteSessionAttachment([FromQuery] DeleteSessionAttachmentCommand command) => await _mediator.Send(command);
    }
}
