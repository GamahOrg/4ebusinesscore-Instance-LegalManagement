using _4EPlatform.Application.Features.KPIsFeatures.JudicialIndicatorsFeatures.CauseDuration;
using _4EPlatform.Application.Features.KPIsFeatures.JudicialIndicatorsFeatures.CountCauses.Query;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.JudicialIndicatorsController
{
    public class JudicialIndicatorsController : BaseController
    {
        private readonly IMediator _mediator;

        public JudicialIndicatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCausesCount")]
        public async Task<ResponseDTO> CausesCount([FromQuery] GetCountCausesDTO dto)
        {
            return await _mediator.Send(new GetCountCausesQuery(dto));
        }
        [HttpGet("GetCausesDuration")]
        public async Task<ResponseDTO> CausesDuration()
        {
            return await _mediator.Send(new GetCauseDurationQuery());
        }
    }
}
