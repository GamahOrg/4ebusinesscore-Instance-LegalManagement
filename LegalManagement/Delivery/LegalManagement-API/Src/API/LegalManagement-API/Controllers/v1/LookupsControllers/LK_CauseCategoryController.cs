using _4EPlatform.Application.Features.LK_CauseCategoryFeatures.Command.Delete;
using _4EPlatform.Application.Features.LK_CauseCategoryFeatures.Command.Post;
using _4EPlatform.Application.Features.LK_CauseCategoryFeatures.Command.Put;
using _4EPlatform.Application.Features.LK_CauseCategoryFeatures.Query.GetAll;
using _4EPlatform.Application.Features.LK_CauseCategoryFeatures.Query.GetById;
using _4EPlatform.Application.Features.LK_Judgement.Command.Delete;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.LookupsControllers
{

    public class LK_CauseCategoryController : BaseController
    {
        public ResponseDTO _responseDto;
        private readonly IMediator _mediator;

        public LK_CauseCategoryController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }

        [HttpPost("PostLK_CauseCategory")]
        public async Task<ResponseDTO> PostLK_CauseCategory([FromBody] PostLK_CauseCategoryCommand command)
           => await _mediator.Send(command);

        [HttpPut("PuttLK_CauseCategory")]
        public async Task<ResponseDTO> PuttLK_CauseCategory([FromBody] PutLK_CauseCategoryCommand command)
            => await _mediator.Send(command);
        [HttpDelete("DeleteLK_CauseCategory")]
        public async Task<ResponseDTO> DeleteLK_CauseCategory(DeleteLK_CauseCategoryByIdCommand command) => await _mediator.Send(command);
        [HttpGet("GetAllLK_CauseCategories")]
        public async Task<ResponseDTO> GetAllLK_CauseCategorirs([FromQuery] GetAllLK_CauseCategoryQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("GetLK_CauseCategoryById/{Id}")]
        public async Task<ResponseDTO> GetLK_CauseCategoryById(int Id) => await _mediator.Send(new GetLK_CauseCategoryByIdQuery { Id = Id });
    

}
}
