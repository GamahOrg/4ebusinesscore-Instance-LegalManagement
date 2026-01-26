using _4EPlatform.Application.Features.KPIsFeatures.IndicatorsJudgementGroundFeatures;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsJudgementGround
{
    public class IndicatorsJudgementGroundController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsJudgementGroundController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDTO> JudgementGroundsCount()
        {
            return await _mediator.Send(new IndicatorsJudgementGroundQuery());
        }
    }
}
