using _4EPlatform.Application.Features.LK_Stage.Command.Delete;
using _4EPlatform.Application.Features.LK_Stage.Command.Post;
using _4EPlatform.Application.Features.LK_Stage.Command.Put;
using _4EPlatform.Application.Features.LK_Stage.Query.GetAll;
using _4EPlatform.Application.Features.LK_Stage.Query.Getbyid;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.LookupsControllers
{
    public class LK_StageController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public LK_StageController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostLK_Stage")]
        public async Task<ResponseDTO> PostLK_Stage([FromBody] PostLK_StageCommand command) => await _mediator.Send(command);

        [HttpPut("PutLK_Stage")]
        public async Task<ResponseDTO> PutLK_Stage([FromBody] PutLK_StageCommand command) => await _mediator.Send(command);

        [HttpDelete("DeleteLK_Stage")]
        public async Task<ResponseDTO> DeleteLK_Stage(DeleteLK_StageCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllLK_Stage")]
        public async Task<ResponseDTO> GetAllLK_Stage(Guid? CauseId) => await _mediator.Send(new GetAllLk_StageQuery()
        {
            CauseId = CauseId
        });
        [HttpGet("GetLK_Satgebyid")]
        public async Task<ResponseDTO> GetLK_Satgebyid([FromQuery] GetLK_StagebyidQuery query) => await _mediator.Send(query);
    }
}
