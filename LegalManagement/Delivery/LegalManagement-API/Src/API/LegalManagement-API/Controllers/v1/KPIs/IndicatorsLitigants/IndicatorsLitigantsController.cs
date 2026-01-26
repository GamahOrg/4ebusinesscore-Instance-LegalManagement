using _4EPlatform.Application.Features.KPIsFeatures.IndicatorsLitigantFeatures;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsLitigants
{
    public class IndicatorsLitigantsController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsLitigantsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDTO> LitigantsCount()
        {
            return await _mediator.Send(new IndicatorsLitigantQuery());
        }
    }
}
