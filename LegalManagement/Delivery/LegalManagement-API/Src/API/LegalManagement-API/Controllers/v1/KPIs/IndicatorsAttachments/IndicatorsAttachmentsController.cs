using _4EPlatform.Application.Features.KPIsFeatures.IndicatorsAttachments;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.KPIs.IndicatorsAttachments
{
    public class IndicatorsAttachmentsController : BaseController
    {
        private readonly IMediator _mediator;

        public IndicatorsAttachmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDTO> AttcahmentIndicators()
        {
            return await _mediator.Send(new IndicatorsAttachmentsQuery());
        }
    }
}
