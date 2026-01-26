using _4EPlatform.Application.Features.JedgementGroundFeature.Command.Delete;
using _4EPlatform.Application.Features.JedgementGroundFeature.Command.Post;
using _4EPlatform.Application.Features.JedgementGroundFeature.Command.Put;
using _4EPlatform.Application.Features.JedgementGroundFeature.Query.GetById;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.JedgementGround
{

    public class JedgementGroundController : BaseController
    {
        private readonly IMediator _mediator;

        public JedgementGroundController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region post 
        [HttpPost("PostJedgementGround")]
        public async Task<ResponseDTO> PostJedgementGround([FromForm] PostJedgementGroundCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
        #region Put
        [HttpPut("PutJedgementGround/{Id}")]
        public Task<ResponseDTO> PutJedgementGround(Guid Id, [FromForm] _4EPlatform.Application.Features.JedgementGroundFeature.Command.Put.JedgementGroundDto command)
        {
            return _mediator.Send(new PutJedgementGroundCommand
            {
                Id = Id,
                JedgementGroundDto = command
            });
        }
        #endregion
        #region delete 
        [HttpDelete("DeleteJedgementGround/{Id}")]
        public async Task<ResponseDTO> DeleteJedgementGround(Guid Id, Guid CauseId)
        {
            return await _mediator.Send(new DeleteJedgementGroundCommand { Id = Id, CauseId = CauseId });
        }
        #endregion
        #region Get
        [HttpGet("GetJedgementGroundById/{Id}")]
        public async Task<ResponseDTO> GetJedgementGroundById(Guid Id)
        {
            return await _mediator.Send(new GetJedgementGroundByIdQuery { Id = Id });
        }
        #endregion
    }
}
