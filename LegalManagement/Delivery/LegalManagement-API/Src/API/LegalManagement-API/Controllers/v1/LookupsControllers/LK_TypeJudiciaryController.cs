



using _4EPlatform.Application.Features.LK_TypeJudiciaryFeatures.Command.Delete;
using _4EPlatform.Application.Features.LK_TypeJudiciaryFeatures.Command.Post;
using _4EPlatform.Application.Features.LK_TypeJudiciaryFeatures.Command.Put;
using _4EPlatform.Application.Features.LK_TypeJudiciaryFeatures.Query.GetAll;
using _4EPlatform.Application.Features.LK_TypeJudiciaryFeatures.Query.GetById;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.LookupsControllers
{
   
    public class LK_TypeJudiciaryController : BaseController
    {
        private readonly IMediator _mediator;

        public LK_TypeJudiciaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseDTO> PostLK_TypeJudiciary( PostLK_TypeJudiciaryDto dto)
           => await _mediator.Send(new PostLK_TypeJudiciaryCommand(dto));

        [HttpPut]
        public async Task<ResponseDTO> PutLK_TypeJudiciary(int Id , PutLK_TypeJudiciaryDto dto)
            => await _mediator.Send(new PutLK_TypeJudiciaryCommand ( dto, Id));
        [HttpDelete]
        public async Task<ResponseDTO> DeleteLK_TypeJudiciary( int Id) => await _mediator.Send(new DeleteLK_TypeJudiciaryCommand (Id));
        [HttpGet]
        public async Task<ResponseDTO> GetAllLK_TypeJudiciaries( [FromQuery]GetAllLK_TypeJudiciariesRequest dto)
        {
            return await _mediator.Send(new GetAllLK_TypeJudiciariesQuery(dto));
        }
        [HttpGet("Id")]
        public async Task<ResponseDTO> GetLK_TypeJudiciaryById(int Id) => await _mediator.Send(new GetLK_TypeJudiciaryByIdQuery(Id));
    }
}
