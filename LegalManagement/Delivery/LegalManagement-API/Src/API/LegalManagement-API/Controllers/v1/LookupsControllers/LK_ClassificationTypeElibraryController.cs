using _4EPlatform.Application.Features.LK_ClassificationTypeELibraries.Command.Delete;
using _4EPlatform.Application.Features.LK_ClassificationTypeELibraries.Command.Post;
using _4EPlatform.Application.Features.LK_ClassificationTypeELibraries.Command.Put;
using _4EPlatform.Application.Features.LK_ClassificationTypeELibraries.Query.GetAll;
using _4EPlatform.Application.Features.LK_ClassificationTypeELibraries.Query.GetById;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.LookupsControllers
{
    public class LK_ClassificationTypeElibraryController : BaseController
    {
        public ResponseDTO _responseDto;
        private readonly IMediator _mediator;

        public LK_ClassificationTypeElibraryController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }

        [HttpPost("PostLK_ClassificationTypeElibrary")]
        public async Task<ResponseDTO> PostLK_ClassificationTypeElibrary([FromBody] PostLK_ClassificationTypeElibraryCommand command)
           => await _mediator.Send(command);

        [HttpPut("PutLK_ClassificationTypeElibrary")]
        public async Task<ResponseDTO> PutLK_ClassificationTypeElibrary([FromBody] PutLK_ClassificationTypeElibraryCommand command)
            => await _mediator.Send(command);
        [HttpDelete("DeleteLK_ClassificationTypeElibrary")]
        public async Task<ResponseDTO> DeleteLK_ClassificationTypeElibrary(DeleteLK_ClassificationTypeELibrariesByIdCommand command) => await _mediator.Send(command);
        [HttpGet("GetAllLK_ClassificationTypeElibraries")]
        public async Task<ResponseDTO> GetAllLK_ClassificationTypeElibraries([FromQuery] GetAllLK_ClassifiactionTypeElibraryQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("GetLK_ClassificationTypeElibraryById/{Id}")]
        public async Task<ResponseDTO> GetLK_ClassificationTypeElibraryById(int Id) => await _mediator.Send(new GetByIdLK_ClassifiactionTypeElibraryQuery { Id = Id });

    }
}
