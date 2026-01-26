using _4EPlatform.Application.Features.LK_IdentityTypeFeatures.Command.Delete;
using _4EPlatform.Application.Features.LK_IdentityTypeFeatures.Command.Post;
using _4EPlatform.Application.Features.LK_IdentityTypeFeatures.Command.Put;
using _4EPlatform.Application.Features.LK_IdentityTypeFeatures.Query.GetAll;
using _4EPlatform.Application.Features.LK_IdentityTypeFeatures.Query.GetById;
using _4EPlatform.Application.Features.LK_Judgement.Command.Delete;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.LookupsControllers
{
    public class LK_IdentityTypeController : BaseController
    {
        public ResponseDTO _responseDto;
        private readonly IMediator _mediator;

        public LK_IdentityTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("PostLK_IdentityType")]
        public async Task<ResponseDTO> PostLK_IdentityType([FromBody] PostLK_IdentityTypeCommand command) => await _mediator.Send(command);

        [HttpPut("PuttLK_IdentityType")]
        public async Task<ResponseDTO> PuttLK_IdentityType([FromBody] PutLK_IdentityTypeCommand command) => await _mediator.Send(command);
        [HttpDelete("DeleteLK_IdentityType")]
        public async Task<ResponseDTO> DeleteLK_IdentityType(DeleteLK_IdentityTypeByIdCommand command) => await _mediator.Send(command);
        [HttpGet("GetAllLK_IdentityTypes")]
        public async Task<ResponseDTO> GetAllLK_IdentityTypes([FromQuery] GetAlLK_IdentityTypeQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("GetLK_IdentityTypeById/{Id}")]
        public async Task<ResponseDTO> GetLK_IdentityTypeById(int Id) => await _mediator.Send(new GetLK_IdentityTypeByIdQuery { Id = Id });

    }
}
