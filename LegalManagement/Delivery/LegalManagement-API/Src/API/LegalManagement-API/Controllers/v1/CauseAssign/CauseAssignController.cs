

using _4EPlatform.Application.Features.CauseAssignFeature.Command.Delete;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.CauseAssign
{

    public class CauseAssignController : BaseController
    {
        private readonly IMediator _mediator;

        public CauseAssignController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpDelete("DeleteCausAssign/Id")]
        public async Task<ResponseDTO> Delete( Guid Id) => await _mediator.Send(new DeleteCauseAssignCommand { Id =Id});
    }
}
