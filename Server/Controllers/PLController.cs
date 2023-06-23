using Lab4.Server.Data;
using Lab4.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PLController : Controller
    {
        private readonly ILogger<PLController> _logger;
        private readonly EFTypePLRepository _repository;

        private static Guid SelectedPL;
        private static Guid SelectedTypePLId;

        public PLController(ILogger<PLController> logger, EFTypePLRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        public IndexViewModel Get()
        {
            var typePLs = _repository.GetLists();

            if (typePLs.Any())
            {
                if (SelectedTypePLId == Guid.Empty)
                {
                    var First = _repository.GetTypePById(typePLs.First().Id);
                    return new IndexViewModel(typePLs, First.Id, First.ProgrammingLanguages);
                }
                else
                {
                    var selectedTypePL = _repository.GetTypePById(SelectedTypePLId);
                    return new IndexViewModel(typePLs, selectedTypePL.Id, selectedTypePL.ProgrammingLanguages);
                }
            }
            else
            {
                return new IndexViewModel(typePLs, Guid.Empty, null);
            }
        }

        [HttpPost]
        [Route("PostAdd")]
        public async Task PostAdd([FromBody] ProgrammingLanguage item)
        {
            var List = _repository.GetListsById(SelectedPL);
            await _repository.RemoveById(SelectedPL);
            List.ProgrammingLanguages.Add(item);
            await _repository.Update(List);
        }

        [HttpPost]
        [Route("PostRemove")]
        public async Task PostRemove([FromBody] Guid ItemId)
        {

            var List = _repository.GetTypePById(SelectedPL);
            await _repository.DeleteTypePByIdAsync(SelectedPL);
            List.ProgrammingLanguages.Remove(List.ProgrammingLanguages.Single(x => x.Id == ItemId));
            await _repository.Update(List);
        }
        [HttpPost]
        [Route("PostListId")]
        public void PostListId([FromBody] Guid Id)
        {
            SelectedTypePLId = Id;
        }

        [HttpPost]
        [Route("PostId")]
        public void PostId([FromBody] Guid Id)
        {
            SelectedPL = Id;
        }

        [HttpPost]
        [Route("redirectTypePL")]
        public IActionResult redirectTypePL()
        {
            return RedirectToPage("TypePLs");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
