namespace FrölundaArcade.Server.Interfaces;

public interface ICategoriesReadService
{
    Task<IEnumerable<Category>> GetAll();
}