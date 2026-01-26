using _4EPlatform.Application.Features.LitigantFeature.Command.Delete;
using _4EPlatform.Application.Features.LitigantFeature.Command.Post;
using _4EPlatform.Application.Features.LitigantFeature.Command.PostLitigantCause;
using _4EPlatform.Application.Features.LitigantFeature.Command.Put;
using _4EPlatform.Application.Features.LitigantFeature.Query.GetAll;
using _4EPlatform.Application.Features.LitigantFeature.Query.GetAllByCauseId;
using _4EPlatform.Application.Features.LitigantFeature.Query.GetById;
using _4EPlatform.Application.Features.LitigantFeature.Query.GetCausesForLitigant;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.Litigant
{
    public class LitigantController : BaseController
    {
        private readonly IMediator _mediator;
        public LitigantController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllLitigant")]
        public async Task<ResponseDTO> GetAllLitigant([FromQuery] LitigantSearchDTO dto)
        {
            return await _mediator.Send(new GetAllLitigantCommand(dto));
        }
        [HttpGet("GetLitigantById/{Id}")]
        public async Task<ResponseDTO> GetLitigantById(Guid Id)
        {
            return await _mediator.Send(new GetLitigantByIdCommand(Id));
        }
        [HttpPost("PostLitigant")]
        public async Task<ResponseDTO> PostLitigant(PostLitigantDto Dto)
        {
            return await _mediator.Send(new PostLitigantCommand(Dto));
        }

        [HttpPost("PostCauseLitigant")]
        public async Task<ResponseDTO> PostCauseLitigant([FromForm]PostLitigantCauseCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("PutLitigant/{Id}")]
        public async Task<ResponseDTO> PutLitigant(Guid Id, PostLitigantDto Dto)
        {
            return await _mediator.Send(new PutLitigantCommand(Id, Dto));
        }
        [HttpDelete("DeleteLitigant/{Id}")]
        public async Task<ResponseDTO> DeleteLitigant(Guid Id)
        {
            return await _mediator.Send(new DeleteLitigantCommand(Id));
        }
        [HttpGet("GetCausesForLitigant/{Id}")]
        public async Task<ResponseDTO> GetCausesForLitigant(Guid Id) => await _mediator.Send
            (new GetLitigantCausesCommand { LitigantId = Id });

        [HttpGet("GetAllLigitantByCauseId/{causeId}")]
        public async Task<ResponseDTO> GetAllLigitantByCauseId(Guid causeId) => await _mediator.Send
           (new GetAllLigitantByCauseIdQuery { CauseId = causeId });
    }
}
