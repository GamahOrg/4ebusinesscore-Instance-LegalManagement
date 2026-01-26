using _4EPlatform.Application.Features.KPIsFeatures.IndicatorsCauseStageFeatures;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsCauseStage
{
    public class IndicatorsCauseStageController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsCauseStageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDTO> CauseStagesCount()
        {
            return await _mediator.Send(new IndicatorsCauseStageQuery());
        }
    }
}
