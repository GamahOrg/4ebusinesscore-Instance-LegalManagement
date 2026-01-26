using _4EPlatform.Application.Features.JedgementGroundFeature.Command.Post;

namespace _4EPlatform_LegalManagement_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class JudgementGroundHangFireController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JudgementGroundHangFireController(IMediator mediator)
        {
            _mediator=mediator;
        }

        #region post 
        [AllowAnonymous]
        [HttpPost("PostJedgementGround")]
        public async Task<ResponseDTO> PostJedgementGround([FromForm] PostJedgementGroundCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
    }
}
