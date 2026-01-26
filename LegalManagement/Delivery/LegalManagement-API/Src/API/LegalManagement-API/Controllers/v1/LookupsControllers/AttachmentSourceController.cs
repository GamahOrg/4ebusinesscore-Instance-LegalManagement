using _4EPlatform.Application.Features.AttachmentSources.Command.Delete;
using _4EPlatform.Application.Features.AttachmentSources.Command.Post;
using _4EPlatform.Application.Features.AttachmentSources.Command.Put;
using _4EPlatform.Application.Features.AttachmentSources.Query.GetAll;
using _4EPlatform.Application.Features.AttachmentSources.Query.GetById;
using _4EPlatform.Application.Features.LK_Judgement.Command.Delete;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.LookupsControllers
{

    public class AttachmentSourceController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public AttachmentSourceController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostLK_AttachmentSource")]
        public async Task<ResponseDTO> PostLK_AttachmentSource([FromBody] PostLK_AttachmentCommand command)
        => await _mediator.Send(command);

        [HttpPut("PutLK_AttachmentSource")]
        public async Task<ResponseDTO> PutLK_AttachmentSource([FromBody] PutAttachmentSourceCommand command)
            => await _mediator.Send(command);
        [HttpDelete("DeleteLK_AttachmentSource")]
        public async Task<ResponseDTO> DeleteLK_AttachmentSource(DeleteAttachmentSourceCommand command) => await _mediator.Send(command);
        [HttpGet("GetAllLkAttachmentSources")]
        public async Task<ResponseDTO> GetAllLkAttachmentSources([FromQuery] GetAllAttachmentSourceQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("GetLkAttachmentSourceById/{Id}")]
        public async Task<ResponseDTO> GetLkAttachmentSourceById(int Id) => await _mediator.Send(new GetLK_AttachmentSourceByIdQuery { Id = Id });
    }
}
