using Microsoft.AspNetCore.Mvc;

namespace FrölundaArcade.Server.Controllers;
public class CategoriesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Category>> GetAll([FromServices] ICategoriesReadService service)
    {
        var categories = await service.GetAll();
        return categories;
    }
}
