using _4EPlatform.Application.Features.LK_Judgement.Command.Delete;
using _4EPlatform.Application.Features.LK_Judgement.Command.Post;
using _4EPlatform.Application.Features.LK_Judgement.Command.Put;
using _4EPlatform.Application.Features.LK_Judgement.Query.GetAll;
using _4EPlatform.Application.Features.LK_Judgement.Query.GetById;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.LookupsControllers
{
    public class LK_JudgementController :BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public LK_JudgementController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostLK_Judgement")]
        public async Task<ResponseDTO> PostLK_Judgement([FromBody] PostLK_JudgementCommand command) => await _mediator.Send(command);
        [HttpPut("PutLK_Judgement")]
        public async Task<ResponseDTO> PutLK_Judgement([FromBody] PutLK_JudgementCommand command) => await _mediator.Send(command);
        [HttpDelete("DeleteLK_Judgement")]
        public async Task<ResponseDTO> DeleteLK_Judgement(DeleteLK_JudgementCommand command) => await _mediator.Send(command);
        [HttpGet("GetAllLK_Judgement")]
        public async Task<ResponseDTO> GetAllLK_Judgement() => await _mediator.Send(new GetAllLK_JudgementQuery());
        [HttpGet("GetLK_Judgementbyid")]
        public async Task<ResponseDTO> GetLK_Judgementbyid([FromQuery] GetbyidLK_JudgementQuery query) => await _mediator.Send(query);
    }
}

