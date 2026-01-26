using _4EPlatform.Application.Features.CauseStageFeatures.CauseStageAttachments.Command.Delete;
using _4EPlatform.Application.Features.CauseStageFeatures.ChangeCauseStage;
using _4EPlatform.Application.Features.CauseStageFeatures.ChangeRedirectorStage;
using _4EPlatform.Application.Features.CauseStageFeatures.ChangeUserCauseStage;
using _4EPlatform.Application.Features.CauseStageFeatures.GetAllCauseStagesForChange;
using _4EPlatform.Application.Features.CauseStageFeatures.GetCauseStageNames;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.CauseStage
{

    public class CauseStageController : BaseController
    {
        private readonly IMediator _mediator;
        public CauseStageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost, Route("ChangeCauseStage")]
        public async Task<ResponseDTO> ChangeCauseStage([FromForm] ChangeCauseStageCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut, Route("ChangeRedirectorStage")]
        public async Task<ResponseDTO> ChangeRedirectorStage(ChangeRedirectorStageCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut, Route("ChangeUserCauseStage")]
        public async Task<ResponseDTO> ChangeUserCauseStage(ChangeUserCauseStageCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet("GetAllLK_StageIdsForChange/{CauseId}")]
        public Task<ResponseDTO> GetAllLK_StageIdsForChange(Guid CauseId)
        {
            return _mediator.Send(new GetAllLK_StageIdsForChangeQuery { CauseId = CauseId });
        }

        //[HttpGet]
        //[Route("GetAllCauseStages")]
        //public Task<ResponseDTO> GetAllCauseStages([FromQuery] GetCauseStagesQuery request)
        //{
        //    return _mediator.Send(request);
        //}

        //[HttpGet("GetCauseStageById/{Id}")]
        //public Task<ResponseDTO> GetCauseStageById(Guid Id)
        //{
        //    return _mediator.Send(new GetCauseStageByIdQuery { CauseStageId = Id });
        //}


        [HttpGet("GetCauseStageNames/{CauseId}")]
        public Task<ResponseDTO> GetCauseStageNames(Guid CauseId)
        {
            return _mediator.Send(new GetCauseStageNamesQuery { CauseId = CauseId });
        }


        #region DeleteStageAttachment
        [HttpDelete("DeleteCauseStageAttachment")]
        public async Task<ResponseDTO> DeleteCauseStageAttachment(DeleteCauseStageAttachmetsCommand command)=> await 
            _mediator.Send(command);
        #endregion
    }
}
