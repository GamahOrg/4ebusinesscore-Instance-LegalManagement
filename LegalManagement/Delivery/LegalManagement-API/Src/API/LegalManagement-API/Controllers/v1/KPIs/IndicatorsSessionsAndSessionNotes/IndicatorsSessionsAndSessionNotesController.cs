using _4EPlatform.Application.Features.KPIsFeatures.IndicatorsSessionsAndSessionNotes;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsSessionsAndSessionNotes
{
    public class IndicatorsSessionsAndSessionNotesController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsSessionsAndSessionNotesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDTO> SessionsCount()
        {
            return await _mediator.Send(new IndicatorsSessionsAndSessionNotesQuery());
        }
    }
}
