using _4EPlatform.Application.Features.JudgmentRefernceFeatures.Command.Post;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.JudgementRefernce
{
    public class JudgementRefernceController : BaseController
    {
        private readonly IMediator _mediator;

        public JudgementRefernceController(IMediator mediator)
        {
            _mediator=mediator;
        }

        #region post 
        [HttpPost("PostJudgementRefernce")]
        public async Task<ResponseDTO> PostJudgementRefernce([FromForm] PostJudgementRefernceCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
    }
}
