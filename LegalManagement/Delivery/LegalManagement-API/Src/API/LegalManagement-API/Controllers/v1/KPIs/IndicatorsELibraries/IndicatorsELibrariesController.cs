using _4EPlatform.Application.Features.KPIsFeatures.IndicatorsELibraries;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsELibraries
{
    public class IndicatorsELibrariesController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsELibrariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDTO> ELibrariesCount()
        {
            return await _mediator.Send(new IndicatorsELibrariesQuery());
        }
    }
}
