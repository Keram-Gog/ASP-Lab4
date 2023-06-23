using Lab4.Server.Data;
using Lab4.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Server.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TypePLManagerController : Controller
{
    private readonly ILogger<PLController> _logger;
    private readonly EFTypePLRepository _repository;

    public TypePLManagerController(EFTypePLRepository typePLRepository, ILogger<PLController> logger)
    {
        _repository = typePLRepository;
        _logger = logger;
    }

    [HttpGet]
    public TypeLanguageManagerModelView Get()
    {
        return new TypeLanguageManagerModelView(_repository.GetLists());
    }

    [HttpPost]
    [Route("PostAdd")]
    public async Task PostAddConfirm([FromBody] string typeplName)
    {
        await _repository.AddTypePL(new TypeLanguage(typeplName));
    }

    [HttpPost]
    [Route("PostRemove")]
    public async Task PostRemove([FromBody] Guid Id)
    {
        await _repository.DeleteTypePByIdAsync(Id);
    }
    public IActionResult Index()
    {
        return View();
    }
}
