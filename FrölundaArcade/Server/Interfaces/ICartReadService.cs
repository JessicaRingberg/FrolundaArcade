namespace FrölundaArcade.Server.Interfaces
{
    public interface ICartReadService
    {
        Task<IEnumerable<CartGame>> GetProductsAsync(string userId);
    }
}
