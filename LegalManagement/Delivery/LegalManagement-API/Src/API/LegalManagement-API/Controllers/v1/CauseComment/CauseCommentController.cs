using _4EPlatform.Application.Features.CauseCommentsFeature.Command.Delete;
using _4EPlatform.Application.Features.CauseCommentsFeature.Command.Post;
using _4EPlatform.Application.Features.CauseCommentsFeature.Command.Put;
using _4EPlatform.Application.Features.CauseCommentsFeature.Query.GetAll;
using _4EPlatform.Application.Features.CauseCommentsFeature.Query.GetById;
using _4EPlatform.Application.Features.CauseCommentsFeature.Query.GetByLoggedInIdConsultative;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.CauseComment
{
    public class CauseCommentController : BaseController
    {
        private readonly IMediator _mediator;

        public CauseCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseDTO> PostCauseComment([FromForm]PostCauseCommentRequest dto)
         => await _mediator.Send(new PostCauseCommentCommand(dto));

        [HttpPut]
        public async Task<ResponseDTO> PutCauseComment([FromForm] PutCauseCommentRequest dto)
            => await _mediator.Send(new PutCauseCommentCommand(dto));
        [HttpDelete]
        public async Task<ResponseDTO> DeleteCauseComment(Guid Id) => await _mediator.Send(new DeleteCauseCommentCommand(Id));
        [HttpGet]
        public async Task<ResponseDTO> GetAllCauseComments([FromQuery] GetAllCauseCommentsRequest dto)
        {
            return await _mediator.Send(new GetAllCauseCommentsQuery(dto));
        }
        [HttpGet("Id")]
        public async Task<ResponseDTO> GetCauseCommentById(Guid Id) => await _mediator.Send(new GetCauseCommentByIdQuery(Id));

        [HttpGet("IsConsultative")]
        public async Task<ResponseDTO> GetIsConsultative([FromQuery] GetByLoggedInIdConsultativeRequest dto )
        {
            return await _mediator.Send(new GetByLoggedInIdConsultativeQuery(dto));
        }
    }
}
