using _4EPlatform.Application.Features.ELibraries.Command;
using _4EPlatform.Application.Features.ELibraries.Command.Delete;
using _4EPlatform.Application.Features.ELibraries.Command.Post;
using _4EPlatform.Application.Features.ELibraries.Command.Put;
using _4EPlatform.Application.Features.ELibraries.Query.GetAll;
using _4EPlatform.Application.Features.ELibraries.Query.GetById;

namespace _4EPlatform_LegalManagement_API.Controllers.v1.ELibraries
{

    public class ELibraryController : BaseController
    {
        private readonly IMediator _mediator;

        public ELibraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GetAllELibrary

        [HttpGet("GetAllELibrary")]
        public async Task<ResponseDTO> GetAllELibrary(int pageNumber, int PageSize, string? SearchWord)
        {
            return await _mediator.Send(new GetAlLibraryQuery { PageNumber = pageNumber, PageSize = PageSize, SearchWord = SearchWord });
        }
        #endregion

        #region GetById 
        [HttpGet("GetELibraryById/{Id}")]
        public async Task<ResponseDTO> GetELibraryById(Guid Id)
        {
            return await _mediator.Send(new GetByIdLibraryQuery { Id = Id });
        }
        #endregion

        #region post 
        [HttpPost("PostELibrary")]
        public async Task<ResponseDTO> PostELibrary([FromForm] ELibraryDTO DTO)
        {
            return await _mediator.Send(new PostELibraryCommand { eLibraryDTO = DTO });
        }
        #endregion

        #region Put 
        [HttpPut("PutELibrary/{Id}")]
        public async Task<ResponseDTO> PutELibrary(Guid Id, [FromForm] ELibraryDTO DTO)
        {
            return await _mediator.Send(new PutELibraryCommand { eLibraryDTO = DTO, Id = Id });
        }
        #endregion

        #region Delete 
        [HttpDelete("DeleteELibrary/{Id}")]
        public async Task<ResponseDTO> DeleteELibrary(Guid Id)
        {
            return await _mediator.Send(new DeleteLibraryCommand { Id = Id });
        }
        #endregion

    }
}
