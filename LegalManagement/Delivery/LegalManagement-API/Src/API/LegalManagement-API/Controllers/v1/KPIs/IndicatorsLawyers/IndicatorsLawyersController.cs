using _4EPlatform.Application.Features.KPIsFeatures.IndicatorsLawyersFeartures;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsLawyers
{
    public class IndicatorsLawyersController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsLawyersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDTO> LawyersCount()
        {
            return await _mediator.Send(new IndicatorsLawyersQuery());
        }
    }
}
