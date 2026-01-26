using _4EPlatform.Application.Features.Causes.Command.AlternativeLawyer.Command.Post;
using _4EPlatform.Application.Features.Causes.Command.Delete;
using _4EPlatform.Application.Features.Causes.Command.FinishCause;
using _4EPlatform.Application.Features.Causes.Command.PostCasuse;
using _4EPlatform.Application.Features.Causes.Command.PutCause;
using _4EPlatform.Application.Features.Causes.Command.PutCauseAssignees;
using _4EPlatform.Application.Features.Causes.Query.GetCauseTitles;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.Causes
{

    public class CausesController : BaseController
    {
        private readonly IMediator _mediator;

        public CausesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet]
        //[Route("GetAllCauses")]
        //public async Task<ResponseDTO> GetAllCauses([FromQuery] CauseQuery query)
        //{
        //    return await _mediator.Send(query);
        //}
        [HttpPost("PostCause")]
        public async Task<ResponseDTO> PostCause([FromForm] PostCausePrame causePram)
        {
            return await _mediator.Send(new PostCauseCommand { PostCause = causePram });
        }

        [HttpPut("FinishCause/{Id}")]
        public async Task<ResponseDTO> FinishCause(Guid Id)
        {
            return await _mediator.Send(new FinishCauseCommand(Id));

        }

        //[HttpGet("{CauseId}")]
        //public Task<ResponseDTO> GetCauseById(Guid CauseId)
        //{
        //    return _mediator.Send(new GetCauseByIdQuery { CauseId = CauseId });
        //}

        //[HttpGet("GetCauseAttachement")]
        //public Task<ResponseDTO> GetCauseAttachementById([FromQuery] GetCauseAttachmentQuery getCauseAttachmentQuery)
        //{
        //    return _mediator.Send(getCauseAttachmentQuery);
        //}

        //[HttpGet("GetCauseHistoryByCauseId")]
        //public Task<ResponseDTO> GetCauseHistoryByCauseId([FromQuery] GetCauseHistoryByCauseIdQuery getCauseHistoryQuery)
        //{
        //    return _mediator.Send(getCauseHistoryQuery);
        //}

        [HttpPut("PutCause")]
        public async Task<ResponseDTO> PutCause([FromForm] PutCausePrame causePram)
        {
            return await _mediator.Send(new PutCauseCommand { PutCause = causePram });
        }


        [HttpDelete("DeleteCause/{Id}")]
        public async Task<ResponseDTO> DeleteCause(Guid Id)
        {
            return await _mediator.Send(new DeleteCauseCommand(Id));
        }

        [HttpGet("GetCauseTitles")]
        public Task<ResponseDTO> GetCauseTitles(string? search)
        {
            return _mediator.Send(new GetCauseTitlesQuery{ Search = search });
        }


        [HttpPost("PostCauseAssignees")]
        public async Task<ResponseDTO> PostCauseAssignees(PutCauseAssigneeCommand command) => await _mediator.Send(command);

        [HttpPost("PostAlternativeLawyer")]
        public async Task<ResponseDTO> PostAlternativeLawyer(PostAlternativeLawyerCommand command) => await _mediator.Send(command);
    }
}
