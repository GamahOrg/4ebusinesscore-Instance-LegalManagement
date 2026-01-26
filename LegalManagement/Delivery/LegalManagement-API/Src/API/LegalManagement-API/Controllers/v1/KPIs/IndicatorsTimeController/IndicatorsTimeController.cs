using _4EPlatform.Application.Features.IndicatorsTime;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsTimeController
{
    public class IndicatorsTimeController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsTimeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDTO> TimeIndicators()
        {
            return await _mediator.Send(new IndicatorsTimeQuery());
        }
    }
}
