namespace FrölundaArcade.Server.Interfaces
{
    public interface ICartWriteService
    {
        Task AddProductAsync(int gameId, string userId);
        Task DeleteProductAsync(int gameId, string userId);
    }
}
