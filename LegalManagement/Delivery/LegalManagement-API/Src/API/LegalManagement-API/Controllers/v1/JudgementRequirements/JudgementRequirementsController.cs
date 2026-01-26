using _4EPlatform.Application.Features.JudgementRquermentsFeature.Command.Delete;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.JudgementRequirements
{
    public class JudgementRequirementsController : BaseController
    {
        private readonly IMediator _mediator;

        public JudgementRequirementsController(IMediator mediator)
        {
            _mediator=mediator;
        }
        #region delete 
        [HttpDelete("JudgementRequierments/{Id}")]
        public async Task<ResponseDTO> JudgementRequirements(Guid Id, Guid CauseId)
        {
            return await _mediator.Send(new DeleteJudgementRequiermentsCommand { Id = Id, CauseId = CauseId });
        }
        #endregion
    }
}
