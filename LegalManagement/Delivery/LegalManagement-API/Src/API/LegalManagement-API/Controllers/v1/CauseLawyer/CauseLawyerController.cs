using _4EPlatform.Application.Features.CauseLawyer.Command.Delete;
using _4EPlatform.Application.Features.CauseLawyer.Command.Post;
using _4EPlatform.Application.Features.CauseLawyer.Command.Put;
namespace _4EPlatform_LegalManagement_API.Controllers.v1.CauseLawyer
{

    public class CauseLawyerController : BaseController
    {
        private readonly IMediator _mediator;

        public CauseLawyerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")]
        public async Task<ResponseDTO> Post(PostCauseLawyerDto causeLawyerDto)
        {
            return await _mediator.Send(new PostCauseLawyerCommand { postCauseLawyerDto = causeLawyerDto });
        }

        [HttpPut("Put")]
        public async Task<ResponseDTO> Put(PutCauseLawyerCommand putCauseLawyer)
        {
            return await _mediator.Send(putCauseLawyer);

        }

        [HttpDelete("Delete")]
        public async Task<ResponseDTO> Delete(DeleteLawyerCommand command) => await _mediator.Send(command);
      


    }
}
