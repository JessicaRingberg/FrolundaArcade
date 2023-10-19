using FrölundaArcade.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace FrölundaArcade.Server.Services;

public class CategoriesReadService : ICategoriesReadService
{
    private readonly AppDbContext _context;

    public CategoriesReadService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }
}
